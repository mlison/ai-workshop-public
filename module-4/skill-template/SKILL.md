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

# About the `skills:` frontmatter field — important gotcha for sub-agent users.
# SKILL.md itself does not take a skills: field; this lives on *custom agent*
# definitions (not skills). The reason it's worth mentioning HERE: sub-agents
# spawned via the Task tool do NOT automatically inherit the parent session's
# skill library. If you want this skill usable inside a sub-agent, the agent's
# own frontmatter has to declare it explicitly:
#
#   # In a custom agent definition file, NOT in this SKILL.md:
#   ---
#   name: code-reviewer
#   description: Reviews code against team conventions.
#   skills:
#     - <this-skill-name>
#     - any-other-skill-the-agent-needs
#   ---
#
# Without that declaration, the sub-agent runs with whatever the agent
# definition allowed, not the project's broader skill set. Easy to forget
# when you've just authored a great skill and wonder why parallel agents
# aren't using it.
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

## Helper scripts (optional)

<!-- If this skill benefits from helper scripts (validation, generation, parsing, lookups),
     drop them in the same directory as this SKILL.md. Then in the Steps section above,
     tell the agent to RUN the script — never to READ it.

       Bad:  "Read .claude/skills/<name>/validate.sh and follow what it does"
       Good: "Run .claude/skills/<name>/validate.sh against the input"

     Why this matters: executing a script consumes only the *output* in context.
     Reading the script pulls the entire source into the context window forever.
     Same logic for large reference data (JSON catalogs, lookup tables, fixtures) —
     have the agent query them via a script, not load them whole.

     This is the script-side equivalent of progressive disclosure: keep the heavy
     stuff out of the context window until the moment it's actually needed. -->

## Examples

<!-- Optional: one or two example input -> output pairs to anchor the skill. -->
