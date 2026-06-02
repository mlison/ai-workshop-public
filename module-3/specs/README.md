# Plans

Single source of truth for active and historical implementation plans.

## Naming convention

`YYYY-MM-DD_HHMM-short-description.md`

Example: `2026-04-15_1100-vitest-snapshot-workflow.md`.

## What lives in a plan

See `../AGENTS.md` §3.1 for the plan structure: intent, goal, acceptance criteria, constraints, situational context, test strategy, out-of-scope. Plans are *living documents* during implementation and gain a `Reflection` section on completion.

## Lifecycle

- Drafted in the Plan Phase.
- Updated continuously during the Implementation Phase.
- Reflection appended in the Merge Phase.
- Plans stay in this directory after merge — they're the audit trail.

## When *not* to use a plan

Trivial changes (typo fixes, one-line config tweaks, dependency bumps) don't need a plan. AGENTS.md sets the threshold around 5 tool calls or file changes.
