# Building Feedback Loops

To ensure code quality and documentation are working correctly, we implement a continuous feedback loop.

## Quality Gates:
1. **Unit Tests (XUnit)**: Must reach 100% coverage for all business logic in `Features/`.
2. **Contract Validation**: Every Request/Response must be checked for Size, Length, and Security.
3. **E2E Validation (Playwright)**: Automated UI/API flow tests.
4. **Observability**: Every handler must log key events and be traceable via the Observability Pattern.

## Automation Steps:
- **Pre-Commit**: Run `dotnet test` locally.
- **CI Pipeline**: GitHub Actions trigger on push to `feature/*` branches.
- **Feedback**: If a test fails, the agent must analyze the failure log and propose a fix before the PR is merged.

## Documentation Feedback:
- After every significant logic change, the `docs/ARCHITECTURE.md` or relevant ADRs must be updated.
- The agent should verify that the updated documentation matches the implementation.
