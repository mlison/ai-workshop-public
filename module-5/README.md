# Module 5 Exercise -- Reviewing the list_routes PR

You're a reviewer on the DispatchKit Core team. A teammate has opened a PR that implements the `list_routes` tool you all spec'd together. Your job is to review it before merge.

## What's here

- `spec.md` -- the spec you agreed before implementation. Treat as approved.
- `pr-description.md` -- the PR description as written by the implementer.
- `typescript/proposed/` -- the files in the PR. Treat this as the diff against `module-4/typescript/mcp-dispatchkit-core/`. New file: `typescript/proposed/src/tools/list-routes.ts`. Modified files: `typescript/proposed/src/data/routes.ts`, `typescript/proposed/src/index.ts`. (Other language variants land under sibling folders, e.g. `csharp/proposed/`.)

## The exercise

Use Claude Code to review the proposed changes against the spec. For each divergence you find:

1. Identify it precisely. Which line? Which acceptance criterion does it violate?
2. Decide who wins: the spec or the code. Why?
3. Decide what action follows: change the code, or update the spec?

This is the **golden rule** in practice. When reality diverges from the spec, fix the spec first if the new reality is better. Fix the code first if the spec was right. Doing nothing is wrong.

## Suggested approach

- Read through `spec.md` and `typescript/proposed/src/tools/list-routes.ts`.
- Ask Claude something like: "Compare the implementation of list_routes in @typescript/proposed/src/tools/list-routes.ts against the spec in @spec.md. Identify any divergence between what the spec asks for and what the code does. Don't fix anything -- just enumerate."
- Iterate. Push back. Don't accept Claude's first answer if it skipped something.
- For each divergence Claude finds, decide the action.

## Wrap

We'll debrief together. Be ready to share:
- What divergences you found.
- Which way you'd resolve each.
- Anything Claude missed (or hallucinated).
