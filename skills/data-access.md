# Skill: Data Access (EF, Dapper, SQL, CosmosDB)
## Core Competencies
- **Hybrid Approach**: Use EF Core for standard CRUD operations, complex object graphs, and change tracking. Use Dapper for high-performance read queries and complex SQL joins.
- **SQL Optimization**: 
    - Avoid `SELECT *`.
    - Use `AsNoTracking()` for read-only EF queries.
    - Explicitly define `SqlParameter` for Dapper to prevent injection.
    - Ensure queries are SARGable for index usage.
- **Cosmos DB Best Practices**:
    - **Partitioning Strategy**: Select high-cardinality partition keys (e.g., `/userId`) to avoid "hot partitions".
    - **RU Optimization**: Understand RU costs for Point Reads vs. Queries; minimize cross-partition queries.
    - **Index Analysis**: Analyze every query in the `CosmosDBAccess` layer. If a query is performed on non-indexed properties or across partitions without a partition key, it must flag a "Missing Index" warning and suggest the specific `IncludedPaths`.
    - **RU Telemetry**: Capture the `RequestCharge` from the `ResponseHeader` for every operation. Log: `Request_ID`, `Operation_Name`, `Request_Charge`, `Execution_Time_Ms`, `Partition_Key_Value`.

## Implementation Guidelines
- **Repository Pattern**: Abstract both EF and Dapper behind a repository or service layer to maintain business logic purity.
- **Migrations**: Use EF Core Migrations for schema changes; keep Dapper queries in sync with the schema.
- **Connection Management**: Use a singleton `CosmosClient` instance to avoid socket exhaustion.
- **Error Handling**: Implement retry logic specifically for `429` (Too Many Requests) and `408` (Request Timeout) statuses.
