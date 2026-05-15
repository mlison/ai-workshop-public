# Release-notes pattern variant

The same primitives (read context, call LLM, post somewhere) compose into other patterns. Release-notes generation on tag push is the obvious second example.

## What it does

On `git tag` push (e.g., `v0.2.0`):

1. Collect commit messages between the new tag and the previous tag.
2. Call Claude to write structured release notes.
3. Print the result (workshop demo) or post to a wiki page / Teams channel (production).

## How to set it up

For the workshop demo, you don't need to actually run this. Show the YAML and the prompt, walk through it, point at the same primitives as the triage pipeline. Don't run it live — saves time.

If you want to demo it live as a stretch goal:

1. Create branch `feature/release-notes` from main.
2. Replace `azure-pipelines.yml` with the contents of `release-notes-pipeline.yml` in this directory.
3. Push the branch plus an annotated tag:
   ```sh
   git tag -a v0.1.0 -m "first release"
   git push origin v0.1.0
   ```
4. Pipeline triggers on the tag, writes notes, echoes them in the pipeline log.

## Variations beyond this

Same shape works for:

- **Doc generation on merge** — trigger: `pr.merged` event. Output: regenerated docs in a follow-up PR.
- **Risk summary on PR open** — trigger: PR opened with a `release` label. Output: comment summarizing changed surfaces and risk areas.
- **Test scaffold on new file** — trigger: PR opened with new `.ts`/`.tsx` files. Output: stub test files via a new commit.

All of them: trigger → gather context → LLM call → post somewhere. The variable group, REST callback, and prompt are the three composable pieces.

## Files

- `release-notes-pipeline.yml` — the alternative pipeline YAML.
- `release-notes.prompt.txt` — system prompt for the summarization call.
