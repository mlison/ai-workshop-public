---
# Required
name: skill-name-here
description: One sentence on what this skill does and when to use it.

# Optional
# triggers:
#   - "phrase that should activate this skill"
#   - "another phrase"

# Optional — restrict which tools the agent may use while this skill is active.
# If omitted, the skill inherits whatever tools the session already allows.
# If listed, only those tools are usable for the duration of the skill —
# everything else (Bash, Edit, Write, network, etc.) is blocked.
# Useful for: read-only review skills, skills that must not touch the filesystem,
# skills that should only call specific MCP tools. Less typing = tighter blast radius.
# allowed-tools:
#   - Read
#   - Grep
#   - Glob

# Optional — pick a specific model to run this skill on.
# If omitted, the skill uses whatever model the session is using.
# Useful for: cheap-and-fast skills (commit messages, log triage → Haiku),
# heavy-reasoning skills (architectural review, hard refactors → Opus).
# Pinning the model also stabilises behaviour: skills that worked on Sonnet
# yesterday won't silently change when the session upgrades model versions.
# Trade-off: model overrides incur context-window costs (subagent-style spawn)
# and you give up automatic upgrades to newer models.
# model: claude-haiku-4-5      # fastest, cheapest
# model: claude-sonnet-4-6     # balanced default
# model: claude-opus-4-7       # most capable
---

# <Skill name>

<!-- One or two sentences: what the skill does. -->

## When to use

<!-- Which signals tell the agent this is the right tool? Be specific. -->

## Inputs

<!-- What does the user provide? A diff? A file path? A description? -->

## Steps

<!-- How does the skill execute? Step-by-step instructions for the agent. -->

1.
2.
3.

## Output

<!-- What does the skill produce? Format, structure, what "good" looks like. -->

## Examples

<!-- Optional: one or two example input -> output pairs to anchor the skill. -->
