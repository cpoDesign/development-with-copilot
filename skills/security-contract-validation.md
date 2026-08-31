# Skill: Security & Contract Validation
## Core Competencies
- **Input Validation**: Strict validation of all incoming contracts (Size, Length, Range, Format).
- **Overload Protection**: Implement "Fail-Fast" checks to prevent Denial of Service (DoS) via oversized payloads or excessive recursion.
- **Security Testing**: 
    - SQL Injection prevention (via Parameterized queries in Dapper/EF).
    - XSS prevention in WebApi inputs.
    - CSRF and Authorization checks at the boundary.
- **Data Masking**: Ensure PII (Personally Identifiable Information) is not logged or exposed in DTOs.

## Implementation Guidelines
- **Boundary Validation**: Every public API and Service entry point must validate the contract size and length.
- **FluentValidation**: Use FluentValidation for complex business rules; use DataAnnotations for simple property constraints.
- **Defense in Depth**: Validate data at the WebApi layer, the Service layer, and (where applicable) the Database layer.
- **Edge Case Coverage**: Unit tests (xUnit) must cover boundary conditions (e.g., MaxLength, MinLength, Nulls, Empty strings).
