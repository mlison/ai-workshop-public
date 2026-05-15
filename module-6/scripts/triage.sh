#!/usr/bin/env bash
# AI triage for failed CI runs.
# Reads pipeline logs + git diff, asks Claude to explain the failure,
# posts the explanation as a PR comment via the ADO REST API.

set -euo pipefail

# Required environment (set by azure-pipelines.yml):
#   ANTHROPIC_API_KEY
#   SYSTEM_ACCESSTOKEN
#   AZDO_ORG_URL          e.g. https://dev.azure.com/<org>/
#   AZDO_PROJECT          e.g. DispatchKit
#   AZDO_REPO_ID
#   PR_ID
#   TARGET_BRANCH
#   LOG_PATH              path to combined pipeline logs

# Skip if not a PR build
if [[ -z "${PR_ID:-}" || "$PR_ID" == "0" ]]; then
  echo "Not a PR build — skipping triage."
  exit 0
fi

# Skip if no logs to triage
if [[ ! -f "$LOG_PATH" ]]; then
  echo "No logs at $LOG_PATH — skipping triage."
  exit 0
fi

# 1. Gather context (cap to avoid huge prompts)
LOGS=$(tail -c 20000 "$LOG_PATH")

# System.PullRequest.TargetBranch returns "refs/heads/main" — strip the prefix
TARGET_BRANCH_NAME="${TARGET_BRANCH#refs/heads/}"

# PR builds checkout the merge ref but may not track origin/<target> as a remote ref.
# Fetch it explicitly so the diff has something to compare against.
git fetch --no-tags origin "$TARGET_BRANCH_NAME:refs/remotes/origin/$TARGET_BRANCH_NAME" 2>/dev/null || true

DIFF=$(git diff "origin/$TARGET_BRANCH_NAME...HEAD" -- 'src/**' '*.ts' '*.tsx' 2>/dev/null | head -c 30000)
[[ -z "$DIFF" ]] && DIFF="(diff unavailable)"

echo "Diff length: ${#DIFF} bytes (target=$TARGET_BRANCH_NAME)"

# 2. Read system prompt
SYSTEM_PROMPT=$(cat prompts/triage.system.txt)

# 3. Build user message
USER_MSG=$(jq -n \
  --arg logs "$LOGS" \
  --arg diff "$DIFF" \
  '"Pipeline failed.\n\n=== Failure logs (last 20KB) ===\n" + $logs + "\n\n=== PR diff ===\n" + $diff')

# 4. Call Anthropic
REQUEST=$(jq -n \
  --arg system "$SYSTEM_PROMPT" \
  --arg user "$USER_MSG" \
  '{
    model: "claude-haiku-4-5",
    max_tokens: 1024,
    system: $system,
    messages: [{role: "user", content: $user}]
  }')

RESPONSE=$(curl -sS --fail-with-body https://api.anthropic.com/v1/messages \
  -H "x-api-key: $ANTHROPIC_API_KEY" \
  -H "anthropic-version: 2023-06-01" \
  -H "content-type: application/json" \
  -d "$REQUEST")

# 5. Extract triage text and token usage
TRIAGE_TEXT=$(echo "$RESPONSE" | jq -r '.content[0].text // empty')
INPUT_TOKENS=$(echo "$RESPONSE" | jq -r '.usage.input_tokens // "?"')
OUTPUT_TOKENS=$(echo "$RESPONSE" | jq -r '.usage.output_tokens // "?"')

if [[ -z "$TRIAGE_TEXT" ]]; then
  echo "No triage text in response:"
  echo "$RESPONSE" | jq .
  exit 1
fi

echo "Tokens: $INPUT_TOKENS input, $OUTPUT_TOKENS output"
echo ""
echo "Triage:"
echo "$TRIAGE_TEXT"

# 6. Post the comment to the PR
COMMENT_TEXT="🤖 **AI Triage**

${TRIAGE_TEXT}

*Tokens: ${INPUT_TOKENS} input, ${OUTPUT_TOKENS} output*"

COMMENT_PAYLOAD=$(jq -n \
  --arg text "$COMMENT_TEXT" \
  '{
    comments: [{parentCommentId: 0, content: $text, commentType: 1}],
    status: 1
  }')

POST_URL="${AZDO_ORG_URL}${AZDO_PROJECT}/_apis/git/repositories/${AZDO_REPO_ID}/pullRequests/${PR_ID}/threads?api-version=7.1-preview.1"

echo ""
echo "Posting comment to: $POST_URL"

HTTP_CODE=$(curl -sS \
  -o /tmp/post_response.json \
  -w "%{http_code}" \
  -X POST \
  -H "Authorization: Bearer $SYSTEM_ACCESSTOKEN" \
  -H "Content-Type: application/json" \
  -d "$COMMENT_PAYLOAD" \
  "$POST_URL")

echo "HTTP status: $HTTP_CODE"
echo "Response body:"
cat /tmp/post_response.json
echo ""

if [[ "$HTTP_CODE" =~ ^2 ]]; then
  THREAD_ID=$(jq -r '.id // "unknown"' /tmp/post_response.json)
  echo "Posted thread $THREAD_ID"
else
  echo "Failed to post comment (HTTP $HTTP_CODE)"
  exit 1
fi
