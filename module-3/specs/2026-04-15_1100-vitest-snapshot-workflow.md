# Spec: enable Vitest snapshot review workflow

**Path:** `specs/2026-04-15_1100-vitest-snapshot-workflow.md`
**Status:** merged
**Author:** dispatch-web team

## Intent

We've had several PRs where snapshot tests were updated without review — reviewers don't notice `.snap` file changes in the diff and rubber-stamp them. Establish a workflow that surfaces snapshot changes and requires reviewer acknowledgement.

## Goal

Snapshot test changes are visible in PRs and require a reviewer to mark them as intentional before merge.

## Acceptance criteria

- [x] `package.json` exposes a `test:update-snapshots` script, distinct from `test`.
- [x] Vitest config uses file-based snapshots (default for `.test.tsx` per AGENTS.md §5; verified).
- [x] PR template includes a "snapshot changes reviewed" checkbox.
- [x] AGENTS.md §5 documents the workflow.
- [x] CI fails when `test` is run with `--update` flag passed (we treat that as accidental).

## Constraints

- No new dependencies.
- Must work with the existing CI pipeline (Azure DevOps).
- Must not change behaviour of `yarn workspace <pkg> run test` for unchanged snapshots.

## Situational context

The snapshot-test convention exists in AGENTS.md but enforcement is human-discipline only. This spec adds tooling alignment. The root cause we're addressing: reviewers approve PRs without scrolling through `.snap` diffs.

## Test strategy

- Update a snapshot in a sandbox branch via the new script, verify the diff is reviewable as a separate concern from code changes.
- Run `test --update` in CI, confirm CI fails.
- Open a PR with both code and snapshot changes, verify the PR template prompts both checkboxes.

## Out of scope

- Automated snapshot review (AI or otherwise) — separate spec if pursued.
- Migration off snapshot tests — debated separately; not what this spec is about.

## Reflection

Merged on 2026-04-15. The PR template change was the highest-leverage piece — most snapshot-review failures came from reviewers not noticing `.snap` files in the diff at all. The CI `--update` block was a clean catch that prevented a near-miss in a downstream PR the same week. Lesson: tooling beats discipline when the failure mode is "didn't notice."
