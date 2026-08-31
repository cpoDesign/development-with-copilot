# Skill: Data Access (EF Core & Dapper)
## Core Competencies
- **EF Core**: Use for standard CRUD operations, complex object graphs, and change tracking.
- **Dapper**: Use for high-performance read queries, bulk inserts, and complex SQL joins that EF cannot handle efficiently.
- **SQL Optimization**: 
    - Avoid `SELECT *`.
    - Use `AsNoTracking()` for read-only EF queries.
    - Explicitly define `SqlParameter` for Dapper to prevent injection.
    - Ensure queries are SARGable for index usage.

## Implementation Guidelines
- **Hybrid Approach**: It is acceptable and encouraged to use both EF and Dapper in the same project.
- **Repository Pattern**: Abstract both EF and Dapper behind a repository or service layer to maintain business logic purity.
- **Migrations**: Use EF Core Migrations for schema changes; keep Dapper queries in sync with the schema.
