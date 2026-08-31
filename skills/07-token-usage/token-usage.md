# Token Usage Optimization

To maximize efficiency and stay within context limits, follow these practices:

## Context Management:
1. **Selective Loading**: Only load the `Features/` slice currently being worked on.
2. **Summary Files**: Use `docs/ARCHITECTURE.md` as a high-level summary before deep-diving into code.
3. **Module Isolation**: Avoid opening the entire project if only one feature is needed.

## Code Structure:
- Keep handlers small.
- Use Dependency Injection to keep constructors clean.
- Use DTOs to limit the amount of data passed between layers.

## Agent Instructions:
- When asked for a fix, provide the minimum necessary context (e.g., the handler and its repository interface).
- Avoid "dumping" the entire `Program.cs` or `appsettings.json` unless specifically required.
