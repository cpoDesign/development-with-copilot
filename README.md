# AI-Powered C# Development Workspace

This workspace is configured for high-velocity, multi-agent development using C# and Vertical Slice Architecture.

## Getting Started
1. **AI Context**: Ensure you are aware of `.github/copilot-instructions.md`. All AI agents should read this before starting work.
2. **Coding Standards**: The `.editorconfig` file enforces style. Use `dotnet format` to fix any issues.
3. **Architecture**: Refer to `docs/ARCHITECTURE.md` for the project structure.

## Workflow
- **New Features**: Create a new folder in `src/Features`.
- **Architecture Changes**: Create a new ADR in `docs/ADRs/` before starting.
- **Documentation**: Keep `docs/GUIDE.md` updated.

## CI/CD
Integrated with GitHub Actions. All PRs are subject to:
- `dotnet build`
- `dotnet test`
- Style check via `dotnet format --verify-no-changes`
