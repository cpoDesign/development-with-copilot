# Skill: Copilot Workflow & Prompt Engineering
## Core Competencies
- **Context Management**: Providing the AI with specific files, architectural rules, and previous ADRs.
- **Chain of Thought (CoT)**: Instructing the AI to "think step-by-step" and "reason through the architecture" before generating code.
- **Few-Shot Prompting**: Providing examples of desired output (e.g., "Write a handler following this pattern: [Example]").
- **Iterative Refinement**: Breaking down large tasks into smaller, verifiable sub-tasks.
- **Agent Coordination**: Defining clear boundaries for when to modify shared code vs. local feature code.

## Workflow Guidelines
- **Read First**: AI must read `docs/ARCHITECTURE.md` and `skills/` files before proposing changes.
- **Plan First**: AI must output a "Proposed Plan" before writing any production code.
- **Review**: AI must explain *why* it chose a specific implementation over an alternative.
