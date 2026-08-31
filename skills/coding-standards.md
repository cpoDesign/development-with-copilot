# Skill: Coding Standards (.NET & xUnit)
## Core Competencies
- **Language Features**: Prefer C# 12+ features: Primary Constructors, Records for DTOs/Value Objects, File-Scoped Namespaces.
- **Async/Await**: Standardize `Task` patterns; use `ValueTask` where appropriate; avoid `.Result` and `.Wait()`.
- **Clean Code**: Enforce DRY, SOLID principles, and expressive naming.
- **Testing**: All new features must have corresponding xUnit tests in the same feature folder.
- **Edge Case Coverage**: Tests must explicitly cover boundary conditions (e.g., MinLength, MaxLength, Nulls, Empty strings, and Overload Protection).

## Implementation Guidelines
- **Immutability**: Use `record` types for all data transfer objects.
- **Dependency Injection**: Standard .NET DI with proper lifetime management (Scoped, Singleton, Transient).
- **Error Handling**: Use specific Domain Exceptions for business errors; let System Exceptions bubble up to the middleware.
