# Testing Loop

We follow a TDD (Test-Driven Development) approach to ensure reliability.

## Steps:
1. **Define Requirements**: Identify the input, expected output, and edge cases (Size, Length, Security).
2. **Write Unit Test**: Create an XUnit test in `tests/UnitTests/` (or within the Feature folder) before the implementation.
3. **Implement Code**: Write the minimal code to make the test pass.
4. **Refactor**: Clean up the code while keeping tests green.
5. **E2E Validation**: Create a Playwright test to verify the API endpoint flow.

## Coverage Requirements:
- **Unit Tests**: 100% coverage on business logic.
- **Integration Tests**: Verify Database and Cache interaction.
- **E2E Tests**: Verify the full request/response cycle via Playwright.
