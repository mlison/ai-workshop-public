# DispatchKit Web — AI Triage Demo

Sample TypeScript/React app wired into an Azure DevOps pipeline that runs AI build-failure triage on red builds. Built for the AI workshop's Module 6 (AI in CI/CD).

The demo: when CI fails on a PR, a pipeline step reads the logs + diff, calls Claude to explain the failure, and posts the explanation as a comment on the PR.

## Local

```sh
npm install
npm run dev       # vite dev server
npm run build     # tsc typecheck + vite build
npm test          # vitest
```

## What's where

- `src/` — minimal React app. One utility function with three tests. Just enough to have something testable.
- `azure-pipelines.yml` — main pipeline. Build + test + triage-on-failure.
- `scripts/triage.sh` — Bash script that reads logs + diff, calls Anthropic, posts a PR comment via the ADO REST API.
- `prompts/triage.system.txt` — system prompt for the triage call.
- `demo/` — workshop-day notes: pre-staged broken commits and the release-notes pattern variant.

## ADO setup

Four things to configure before the pipeline can run end-to-end on a failed PR.

### 1. Anthropic API key

Get a key from console.anthropic.com. Set a monthly spending cap in the Anthropic dashboard before anything else — start at $20/month for the workshop, raise later if needed.

### 2. Azure Key Vault secret

Store the API key in Key Vault as `ANTHROPIC-API-KEY` (or any name you prefer — match what the variable group references).

### 3. ADO variable group

In ADO → Pipelines → Library:

- Create a variable group named `ai-secrets`.
- Link it to your Key Vault.
- Map the Key Vault secret to a variable in the group; the variable name needs to be env-var-safe (`ANTHROPIC_API_KEY`, not `ANTHROPIC-API-KEY`).
- Grant the pipeline access to the variable group.

### 4. ADO permissions for the build identity

The triage script posts a PR comment via the ADO REST API using `$(System.AccessToken)`. The build service identity needs **Contribute to pull requests** on the repo:

- Repo settings → Security → search for `<ProjectName> Build Service (<OrgName>)`.
- Allow: *Contribute to pull requests*.

## Running the demo

See `demo/broken-commits.md` for three pre-staged failure modes. The simplest (and recommended for the main demo) is the failing-test option.

## Pattern variations

The same primitives (read context, call LLM, post somewhere) compose into other patterns. See `demo/release-notes-variant.md` for an example: tag push → summarize commits between tags → post release notes.

## Cost control

Triage only runs on failed builds (`condition: failed()`). Approximate cost per run with Haiku 4.5: under $0.01. Bill scales with failure rate, not PR volume.
