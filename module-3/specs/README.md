# Specs

Single source of truth for active and historical implementation specs.

## Naming convention

`YYYY-MM-DD_HHMM-short-description.md`

Example: `2026-04-15_1100-vitest-snapshot-workflow.md`.

## What lives in a spec

See `../AGENTS.md` §3.1 (Spec Phase) for the spec structure: intent, goal, acceptance criteria, constraints, situational context, test strategy, out-of-scope. Specs are *living documents* during implementation and gain a `Reflection` section on completion.

## Lifecycle

- Drafted in the Spec Phase.
- Updated continuously during the Implementation Phase.
- Reflection appended in the Merge Phase.
- Specs stay in this directory after merge — they're the audit trail.

## When *not* to use a spec

Trivial changes (typo fixes, one-line config tweaks, dependency bumps) don't need a spec. AGENTS.md sets the threshold around 5 tool calls or file changes.

## A note on naming

We use *spec* throughout this project. SPDD-style writing (Martin Fowler's article and the broader community) calls the same artifact a *plan*. Treat them as synonymous when reading source material — the structure and lifecycle don't change.
