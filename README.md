# AI workshop materials

For the AI workshop on 2026-05-20. Clone this repo before the workshop and have it ready on your laptop.

## Before the workshop

- **`pre-reading.md`** — vocabulary the workshop assumes (~10 min read).
- **`setup-instructions.md`** — install + auth your AI tool, then a quick pre-flight check (~10 min hands-on).

If you got the email but haven't done these yet, do them now. The pre-flight at the end of `setup-instructions.md` confirms your tool can read files in this repo — that's the smoke test you want passing before you walk in.

## Modules

| Folder | What it is | When we use it |
|---|---|---|
| **`module-3/`** | Team-level context engineering. A sample project with `AGENTS.md`, `.prompts/`, `.skills/`, `specs/`, `doc/`. | We dissect this together in Module 3. The pre-flight check reads `module-3/AGENTS.md`. |
| **`module-4/`** | Giving the agent your team's tools (MCP-led). Pick the language folder for your stack: `typescript/`, `csharp/`, or `python/` — the MCP server you mob-build lives there. `skill-template/` is the language-agnostic solo skill-writing exercise. | Module 4, hands-on. |
| **`module-5/`** | PR-review exercise. `spec.md` and `pr-description.md` are language-agnostic; `csharp/proposed/`, `python/proposed/`, and `typescript/proposed/` hold the code under review. Same four planted divergences from the spec in every variant. | Module 5, hands-on. See `module-5/README.md` for the exercise framing. |
| **`module-6/`** | Read-only reference: the Azure DevOps pipeline + AI triage script from the live demo. | Module 6 is demo-only — you watch, not run. Files are here so you can poke at them after. |

## During the workshop

Bring your laptop with the AI tool authenticated and this repo cloned. We'll work in `module-3/`, then `module-4/`, then `module-5/`. Module 6 runs on a separate Azure DevOps project (you'll see the screen).

## After

Keep the repo around. The samples are reference material — copy patterns into your own projects.

## Recommended reading

- [Martin Fowler — Structured Prompt-Driven Development](https://martinfowler.com/articles/structured-prompt-driven/). The source of much of Module 5's vocabulary (spec-first / plan-first, golden rule, bidirectional sync). The article calls the artifact a "plan"; we use "spec" — same idea. Worth reading even if you only attended the workshop in passing.
- [Anthropic — Claude Code skills](https://docs.claude.com/en/docs/claude-code/skills). Reference for the skill format we used in Module 4.
- [Model Context Protocol](https://modelcontextprotocol.io/). Spec and SDKs for the MCP server pattern from Module 4.
