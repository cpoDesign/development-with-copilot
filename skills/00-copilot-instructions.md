# Module 00: Copilot Instructions - The "Rules of Engagement"

## Overview
Copilot Instructions are the "System Prompts" that define how an AI agent behaves, what rules it must follow, and what context it must prioritize. They are the most powerful tool for ensuring AI-generated code remains consistent with your project's standards.

## How They Work
- **Global Instructions**: Set at the system level (e.g., in Bionic settings or `.github/copilot-instructions.md`).
- **Local Context**: Provided by files in your workspace (like `ARCHITECTURE.md`, `ADRs/`, and the `skills/` folder).
- **Dynamic Loading**: The agent "loads" these instructions based on your request.

## Best Practices for Instructions
1. **Be Explicit**: Instead of "Write clean code," use "Follow the coding standards in `skills/coding-standards.md`."
2. **Be Sequential**: Use "Plan -> Approve -> Execute" to prevent the AI from making incorrect assumptions.
3. **Define Boundaries**: Clearly state what the AI *should not* do (e.g., "Do not modify shared Domain entities without an ADR").
4. **Keep it Updated**: When your project's architecture evolves, update the corresponding instruction file or ADR.

## Workable Exercises
- **Exercise 1**: Create a new rule in `.github/copilot-instructions.md` that requires the AI to always check for "SQL Injection" in every query it writes.
- **Exercise 2**: Ask the AI to "Summarize the current project rules" to see how well it has loaded the instructions from the `skills/` and `docs/` folders.
