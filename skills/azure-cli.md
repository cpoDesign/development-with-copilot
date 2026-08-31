# Skill: Azure CLI & Infrastructure
## Core Competencies
- **Azure CLI commands**: Proficiency in `az group`, `az vm`, `az storage`, `az webapp`, and `az container`.
- **Authentication**: Managing `az login` sessions and service principals for automated tasks.
- **Resource Group Management**: Organizing resources by lifecycle.
- **Deployment**: Using Azure CLI for scriptable deployments and automation.
- **Monitoring**: Basic CLI commands for resource health and logs.

## Implementation Guidelines
- Use variables in scripts for environment-specific values (e.g., `az group create --name $RG_NAME`).
- Always check for resource existence before creation.
- Prefer `az` commands over manual portal actions to ensure reproducibility.
