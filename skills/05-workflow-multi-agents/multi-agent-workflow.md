# Multi-Agent Workflow with Vertical Slice Architecture

This skill defines how multiple agents can work in parallel on a single project without causing merge conflicts or context pollution.

## Strategy: Vertical Slice Architecture
Instead of Horizontal Layers (UI, Business, Data), we use Vertical Slices. Each feature (e.g., `GetProduct`, `CreateOrder`) is a self-contained slice.

### Parallel Work Rules:
1. **Isolated Features**: Agents should work on different folders within `src/TemplateProject/Features/`.
2. **Shared Memory Context**:
   - **Database**: Shared via the `Persistence` layer.
   - **Cache**: Shared via `ICacheService`.
   - **Shared Domain Models**: Defined in `Domain/` (read-only for most agents).
3. **Conflict Prevention**: Use `manage-github-changes` to ensure that changes in one slice do not overwrite another.

## Agent Collaboration Pattern:
- **Architect Agent**: Defines the slice and the `Architecture.md` guidelines.
- **Implementation Agent**: Builds the handler and logic.
- **QA Agent**: Writes unit tests and Playwright E2E tests for that specific slice.

## Implementation Example:
When working on `Products`, an agent should only touch `Features/Products/`. When working on `Orders`, only `Features/Orders/`.
