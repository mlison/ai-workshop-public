# Pre-reading -- AI workshop

## Who this is for

You only need this if you don't already use project-level instructions, skills, or MCP servers in your day-to-day. If you do, skim the "What we cover" section and set the rest aside.

For everyone else: 10-minute read. Gives you the vocabulary the rest of the group already speaks.

## A note on the modules

The workshop's full curriculum has six modules. We're intentionally skipping the first two — basic prompting, autocomplete vs chat vs agent, when AI helps — because your survey responses told us most of you are past that. We start at Module 3 and go through to Module 6 across one 4-hour block.

## What we cover

Four modules.

- **Module 3 -- Team-level context engineering.** Shared `AGENTS.md` / `CLAUDE.md` files, prompt libraries, governance. How to make AI behaviour consistent across the team, not just per-developer.
- **Module 4 -- Giving the agent your team's tools (MCP-led).** Hands-on. MCP is how you give the agent the tools your team already uses. We mob-build an MCP tool together (in TypeScript, C#, or Python — your cohort's facilitator picks the language), then write a skill solo.
- **Module 5 -- Discipline for trustworthy AI output.** When the spec and the implementation diverge: which wins? The "golden rule" of AI-assisted development. PR-review exercise.
- **Module 6 -- AI in CI/CD and pipelines.** AI agents in automated workflows. Azure DevOps patterns. Beyond personal productivity.

You don't need to study any of this in advance. The vocabulary below is what you should walk in *roughly* familiar with so terms don't land cold.

## Vocabulary

### Agent vs chat vs autocomplete

- **Autocomplete** -- inline suggestions as you type. Copilot's original behaviour. Local, narrow.
- **Chat** -- you talk to the model, it answers. May propose edits but doesn't apply them itself.
- **Agent** -- the model reads files, runs commands, writes code, iterates. Claude Code, Cursor's agent mode, Copilot's agent mode. This is what most of the workshop assumes.

### Project-level instructions (CLAUDE.md / AGENTS.md)

A markdown file checked into the repo that the AI agent reads automatically when it starts work in that project. Think of it as a prompt that's always on for anyone running an agent against this codebase.

Typical contents: project description, coding conventions, test commands, "things this project does differently," what to avoid.

`CLAUDE.md` is Claude Code's filename. `AGENTS.md` is the cross-tool standard. Cursor uses `.cursorrules`. Same idea, different filenames.

If this is new to you: drop a two-paragraph `CLAUDE.md` at the root of one of your repos, then ask the agent something it would have answered worse without that file. You'll feel the difference.

### Skills / slash commands

Reusable, named instructions. You write a markdown file describing how to do a specific kind of task -- code review in your team's PR style, generating a unit test in your shape, writing a commit message -- and invoke it later as `/code-review` or similar.

Where they live: usually `.claude/skills/` or `.claude/commands/`. Each skill is a file with frontmatter (when to use it, which tools it needs) and a body (instructions).

Why they matter: they bottle a way of working and let you share it. Tribal knowledge becomes a checked-in asset.

### MCP servers (Model Context Protocol)

A small program that exposes tools the AI agent can call. Each "tool" is a function with a name, a schema, and a handler. The agent decides when to call which based on the description you write.

Examples: a filesystem MCP exposing `read_file` and `write_file`. A GitHub MCP exposing `get_pr` and `comment_on_pr`. A Linear MCP exposing `find_ticket`. You can write your own.

Why they matter: they extend the agent's reach beyond the current codebase -- into your wiki, your ticket tracker, your internal APIs. We mob-build one in Module 4.

### Multi-agent / parallel agents

Running multiple agent sessions at once, often each scoped to its own worktree or task. Useful when work decomposes naturally -- one agent on the backend change, another on the frontend, both reporting back. Or: one agent implementing, another reviewing.

You don't need to know how to set this up in advance. We show it in Module 4.

### Specs (a.k.a. plans)

A written document describing what an agent should do before it starts. You (or the agent) draft the spec; you review and approve; the agent then executes against it. Reduces "AI confidently does the wrong thing" by half a session.

We use "spec" throughout the workshop because the engineering culture this audience comes from associates "plan" with throwaway pre-work, and the artifact we're describing is the opposite — durable, versioned, the source of truth the code is measured against. SPDD (referenced below) calls the same artifact a "plan"; they're the same thing.

Specs run through the day and are the centerpiece of Module 5.

## Setup before the workshop

See `setup-instructions.md` in this folder. Bring your laptop with one AI coding tool installed and authenticated (Claude Code or GitHub Copilot in agent mode), and an account with enough usage limit for the day. We confirm it all works at the start.

## Optional deeper reading

If you want to go further before the workshop -- not required:

- The Martin Fowler article on Structured Prompt-Driven Development (https://martinfowler.com/articles/structured-prompt-driven/). Source of much of Module 5's vocabulary (golden rule, bidirectional sync). The article uses "plan" for what we call "spec" — same artifact.
- Anthropic's docs on Claude Code skills and MCP, or GitHub's docs on Copilot agent mode.
- The MCP SDK README for whichever language you'd actually write in: the TypeScript SDK (`@modelcontextprotocol/sdk`), the .NET SDK (`ModelContextProtocol` NuGet), or the Python SDK (`mcp` PyPI, FastMCP API). The protocol is the same in all three; only the SDK idiom differs.

Don't go down a rabbit hole. The above is plenty.
