# Workshop setup

About 10 minutes if your machine is already a working dev environment.

## What you need

- Laptop with a working terminal (zsh, bash, fish — your choice).
- Git installed.
- One AI coding tool installed and authenticated — **Claude Code** or **GitHub Copilot** (with agent mode). Pick whichever you already use day-to-day; both work for the workshop.
- An active account / subscription for that tool, with enough usage budget for the day.

That's it for the pre-flight. The check below confirms your AI tool can read a file in this repo — that's all the day-of setup needs.

### About the tool choice

The workshop is mostly tool-agnostic — concepts and patterns transfer. Two caveats worth knowing:

- The skill-writing exercise (Module 4) uses Claude Code's skill format specifically. If you're Copilot-only, plan to pair with a Claude user for that 15-minute block, or follow along as an observer.
- The MCP server demo (Module 4) uses Claude Code's commands for adding/listing MCP servers. The MCP protocol is the same in both tools, but the commands you'd type differ.

### About language runtimes

Module 4's MCP sample ships in three languages — TypeScript, C#, Python. **Your facilitator will pick one for the mob** based on your cohort. You don't *need* the runtime installed to follow along on the day (the mob is driver-led; you watch the screen). But if you want to clone the sample and tinker after the workshop, install whichever matches your day-to-day work:

- **TypeScript:** Node.js 20+
- **C#:** .NET 10 SDK (`brew install --cask dotnet-sdk` on macOS)
- **Python:** Python 3.10+ and ideally `uv` or `pip` for venv management

None of these are required to attend.

## Path A — Claude Code

Install (if not already):

```sh
npm install -g @anthropic-ai/claude-code
```

Confirm:

```sh
claude --version
```

Authenticate:

```sh
claude
```

Follow the auth prompts. Run a throwaway prompt — `> hi` — to verify tokens flow.

Anthropic account needs at least $10 in credits or a paid plan with daily headroom.

## Path B — GitHub Copilot

Requires an active GitHub Copilot subscription (individual or via your org).

Install the GitHub Copilot extension in your IDE (VSCode, JetBrains, or compatible). Sign in via the IDE prompt to authenticate with your GitHub account.

Open the Copilot Chat panel and switch to **Agent mode** (look for the mode toggle in the chat panel).

If you want a command-line equivalent, the `gh copilot` extension works for simple queries but doesn't do agent-style file editing — the IDE chat panel in agent mode is the closer match to what we use in the workshop.

## Clone the workshop repo

```sh
git clone https://github.com/mlison/ai-workshop-public.git ai-workshop
cd ai-workshop
```

## Pre-flight check

In the workshop repo, ask your tool to read `module-3/AGENTS.md` — the file we'll dissect first on the day. If your tool can read it and summarise it, your setup works.

**Claude Code:**

```sh
claude
```

Then in the Claude Code session:

```
> read module-3/AGENTS.md and tell me what this project is in 2 sentences
```

**Copilot** (agent mode in your IDE, with the repo open):

```
Read module-3/AGENTS.md and tell me what this project is in 2 sentences.
```

If you get a coherent answer, you're set.

## Bring tabs to the workshop

- The pre-reading: `pre-reading.md`.
- The workshop repo (cloned above).
- Your usual editor.

## If something doesn't work

- Arrive 15 minutes early; we debug then.
- Worst case: show up anyway, pair with someone whose setup works.

## What you don't need

- The MCP SDK (TypeScript, C#, or Python — see *About language runtimes* above), Azure CLI, or any provider-specific SDK installed locally — those run on the demo machine on the day.
- A personal Azure DevOps account — Module 6 is demo-only.
- To read anything inside the workshop repo's per-module directories before the day. We walk through the relevant pieces together.
