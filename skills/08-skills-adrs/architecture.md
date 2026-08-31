# Skill: Architecture (Vertical Slice & ADRs)
## Core Principles
- **Vertical Slice Architecture**: Organize code by feature (use case) rather than by technical layer.
    - `src/Features`: Contains logic for specific features. Each folder should be self-contained.
    - `src/Domain`: Contains shared entities, value objects, and domain logic.
    - `src/Infrastructure`: Contains shared persistence, external API clients, and cross-cutting concerns.
    - `src/WebApi`: Contains the entry points (Controllers/Minimal APIs).
- **Multi-Layer Separation**: Strict boundaries between WebApi, Business Logic (Services), Domain, and Infrastructure.
- **ADR-Driven Context**: ADRs are the source of truth for all configuration and architectural decisions.
- **Shared Memory**: Use ADRs to communicate "Shared Memory Context" when multiple agents work in parallel.

## Workflow
- **New Change**: If a change affects architecture, the agent MUST consult `docs/ADRs/`.
- **Missing ADR**: If no ADR exists for a proposed change, the agent must propose a new ADR before implementation.
- **Parallel Work**: Agents must prioritize creating new types/classes over modifying shared ones to avoid merge conflicts.
