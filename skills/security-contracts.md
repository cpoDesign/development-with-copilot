# Skill: Security & Contract Validation
## Core Competencies
- **Contract Integrity**: Strict validation of all incoming contracts (Size, Length, Range, Format).
- **Overload Protection**: Implement "Fail-Fast" checks to prevent Denial of Service (DoS) via oversized payloads or excessive recursion.
- **Input Validation**: Validate every public API and Service entry point.
- **Security Testing**: 
    - SQL Injection prevention (via Parameterized queries in Dapper/EF).
    - XSS prevention in WebApi inputs.
    - CSRF and Authorization checks at the boundary.
- **Data Masking**: Ensure PII (Personally Identifiable Information) is not logged or exposed in DTOs.

## Implementation Guidelines
- **Boundary Validation**: Validate data at the WebApi layer, the Service layer, and (where applicable) the Database layer.
- **FluentValidation**: Use FluentValidation for complex business rules; use DataAnnotations for simple property constraints.
- **Fail-Fast**: Validate inputs at the entry point of every public method.
