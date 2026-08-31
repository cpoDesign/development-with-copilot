# Module 01: Initial Training - Foundations of AI Context

## 1. Understanding the Context Window
The AI agent does not have a "global" memory of your project. It only knows what is in its current context window. In large repositories, the agent must be "fed" the right information.

## 2. Context Injection Strategy
To ensure the AI remains accurate:
- **Architecture**: Always refer to .
- **Rules**: Always refer to the  directory.
- **Decisions**: Always refer to .

## 3. The "Plan-First" Workflow
**NEVER** let the AI write production code without an approved plan.
- **Step 1**: State the requirement (e.g., "I need a new order validation endpoint").
- **Step 2**: Ask the AI: "Propose a technical plan based on our architecture and skills."
- **Step 3**: Review the plan for:
    - Correct Layer Separation (e.g., logic in , persistence in ).
    - Security (Does it validate input length/size?).
    - Observability (Does it log a CorrelationId?).
- **Step 4**: Approve the plan.
- **Step 5**: Ask the AI to implement the first piece of the plan.

## 4. Workable Exercises
- **Exercise 1**: Open a complex service and ask the AI to "Refactor this following the patterns in ."
- **Exercise 2**: Create a new ADR for a feature and ask the AI to "Implement the feature as described in the new ADR."
