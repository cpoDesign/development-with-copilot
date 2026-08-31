# Skill: .NET C# Development (Multi-Layer & Observability)
## Core Competencies
- **Multi-Layer Architecture**: Strict separation between WebApi, Business Logic (Services), Domain, and Infrastructure.
- **Observability Pattern**: 
    - **Structured Logging**: Every method must log key events with structured data (not just strings).
    - **Tracing**: Ensure `ActivitySource` or `TraceId` is propagated across boundaries (Web -> Service -> Repository).
    - **Metrics**: Expose key performance indicators (KPIs) for high-frequency operations.
- **Async/Await**: Standardized `Task` patterns with `ConfigureAwait(false)` where appropriate.
- **Dependency Injection**: Standard .NET DI with proper lifetime management.

## Implementation Guidelines
- **Fail-Fast**: Validate inputs at the entry point of every public method.
- **Contract Integrity**: Use Records for DTOs to ensure immutability and clear contracts.
- **Cross-Cutting Concerns**: Use Middleware or Decorators for logging and observability to keep business logic clean.
