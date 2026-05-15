# Module 5 Exercise -- Reviewing the list_routes PR

You're a reviewer on the DispatchKit Core team. A teammate has opened a PR that implements the `list_routes` tool you all planned together. Your job is to review it before merge.

## What's here

- `plan.md` -- the plan you agreed before implementation. Treat as approved spec.
- `pr-description.md` -- the PR description as written by the implementer.
- `proposed/` -- the files in the PR. Treat this as the diff against `modules/module-4/sample/mcp-dispatchkit-core/`. New file: `proposed/src/tools/list-routes.ts`. Modified files: `proposed/src/data/routes.ts`, `proposed/src/index.ts`.

## The exercise

Use Claude Code to review the proposed changes against the plan. For each divergence you find:

1. Identify it precisely. Which line? Which acceptance criterion does it violate?
2. Decide who wins: the plan or the code. Why?
3. Decide what action follows: change the code, or update the plan?

This is the **golden rule** in practice. When reality diverges from the plan, fix the plan first if the new reality is better. Fix the code first if the plan was right. Doing nothing is wrong.

## Suggested approach

- Open `plan.md` and `proposed/src/tools/list-routes.ts` in Claude Code.
- Ask Claude something like: "Compare the implementation of list_routes in @proposed/src/tools/list-routes.ts against the plan in @plan.md. Identify any divergence between what the plan asks for and what the code does. Don't fix anything -- just enumerate."
- Iterate. Push back. Don't accept Claude's first answer if it skipped something.
- For each divergence Claude finds, decide the action.

## Wrap

We'll debrief together. Be ready to share:
- What divergences you found.
- Which way you'd resolve each.
- Anything Claude missed (or hallucinated).
