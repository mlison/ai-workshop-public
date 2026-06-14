# Adapting the build-failure triage pattern to your repo

One-page checklist. The full reference lives in [`module-6/`](https://github.com/mlison/ai-workshop-public/tree/main/module-6) of the workshop repo — `azure-pipelines.yml`, `scripts/triage.sh`, and `prompts/triage.system.txt` are the three files to copy. This page lists what to change once you have them.

## Before you start

- An Anthropic or OpenAI account with API access. **Set a monthly budget alert in their dashboard** before you do anything else.
- An Azure Key Vault accessible to your project (or your team's existing one).
- An Azure DevOps service connection to your AI provider, OR direct API key handling via Key Vault.
- Permissions to edit pipeline YAML and create variable groups.

## Steps

### 1. Variable group with the API key

Two paths depending on what your org allows. Both leave the pipeline YAML unchanged.

**Best-practice path** (if you can create Azure Resource Manager service connections):

- Create a service connection: Project Settings → Service connections → New → Azure Resource Manager.
- Variable group: Pipelines → Library → New → tick "Link secrets from an Azure key vault as variables." Pick the service connection and Key Vault. Add `ANTHROPIC-API-KEY`.
- Reference: Microsoft docs on linking variable groups to Key Vault.

**Fallback path** (if your org restricts Entra app registration — common in enterprise tenants; you'll see "Insufficient privileges to create an Entra application" when the service connection wizard fails):

- Variable group: Pipelines → Library → New, name `ai-secrets`.
- Add variable: `ANTHROPIC_API_KEY` → paste your key → click the padlock to mark as secret.
- Save and grant the pipeline access.

The first path gives you Key Vault rotation; the second is simpler to set up. The pipeline YAML references `$(ANTHROPIC_API_KEY)` in both cases.

### 2. Pipeline YAML

Copy `azure-pipelines.yml` from the reference repo. Three changes:

- Update the `variables` block to reference your variable group name.
- Update the triage `script` block to point at your prompt file (or inline your prompt).
- Update the trigger conditions to match your branching strategy.

### 3. Prompt

The reference repo's prompt is in `prompts/triage.txt`. Adapt it:

- Replace project-specific context (tech stack, conventions) with your own.
- Adjust the output format if you want different fields.
- Tighten the persona to match how you'd want a senior engineer to triage a failure.

### 4. Cost cap

In the script that calls the LLM API, set:

- `max_tokens` on the response (start at 800).
- A wall-clock timeout on the pipeline step (start at 60s).
- Selective triggers: only run on failure (`condition: failed()`), only on PRs to `main` if you want.

### 5. Try it

Push a deliberately broken commit. Watch the pipeline fail. Wait for the triage comment.

If the comment is unhelpful: improve the prompt before improving anything else. The prompt is the product.
