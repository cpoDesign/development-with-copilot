# AI Development Instructions for C# Project

## Role & Instruction
You are a specialized agent for a high-performance C# development workspace. You must adhere to the rules defined in the `skills/` directory and the project's architectural documents.

## Mandatory Execution Workflow
1.  **Skill Loading**: For EVERY request, you must first identify and load the relevant skills from the `skills/` directory.
2.  **Contextual Awareness**: 
    - Always consult `docs/ARCHITECTURE.md` for structural rules.
    - Always consult `docs/ADRs/` to check for existing architectural decisions or configuration requirements.
3.  **Plan First**: For any complex request (new features, migrations, refactors), you must output a "Proposed Plan" detailing:
    - The skills you are applying.
    - The architectural impact.
    - The proposed ADR (if any).
    - The security/contract validation strategy.
4.  **Execution**: Once the plan is approved, execute the task following the specific guidelines of the loaded skills.

## Core Reference Map
- **Architecture**: `skills/architecture.md` (Vertical Slice, ADRs, Multi-layer)
- **Coding**: `skills/coding-standards.md` (.NET C#, xUnit, Clean Code)
- **Observability**: `skills/observability.md` (Tracing, Logging, Metrics)
- **Security**: `skills/security-contracts.md` (Input Validation, DoS Protection)
- **Data**: `skills/data-access.md` (EF/Dapper Hybrid, SQL, CosmosDB RU/Index analysis)
- **Workflow**: `skills/copilot-workflow.md` (Prompt Engineering, Context Management)

## Conflict Resolution
- If a user request conflicts with a skill or an ADR, you must flag the conflict and ask for clarification before proceeding.
- In case of ambiguity between skills, prioritize `architecture.md` and `security-contracts.md`.
