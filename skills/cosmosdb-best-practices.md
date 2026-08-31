# Skill: Cosmos DB Best Practices (Advanced)
## Core Competencies
- **Partitioning Strategy**: Selecting high-cardity partition keys (e.g., `/userId`, `/deviceId`) to avoid "hot partitions".
- **Request Unit (RU) Optimization**: Understanding RU costs for Point Reads vs. Queries; minimizing cross-partition queries.
- **Consistency Levels**: Choosing the right trade-off between latency and consistency (Strong, Bounded Staleness, Session, Eventual).
- **Indexing Policies**: Customizing inclusion/exclusion filters to reduce RU costs on write-heavy workloads.
- **TTL (Time to Live)**: Implementing automatic data expiration for transient records.
- **Change Feed**: Utilizing the Change Feed for downstream processing and real-time synchronization.
- **Autoscale vs. Manual**: Strategies for scaling RUs based on traffic patterns.

## Advanced Analysis & Optimization
### 1. Automated Index Suggestions
- **Query-Driven Indexing**: Every query defined in the "Access Layer" (Repositories/Services) must be mapped to a corresponding Indexing Policy.
- **Requirement**: The AI must analyze all `CosmosDBAccess` methods. If a query is performed on non-indexed properties or across partitions without a partition key, it must flag a "Missing Index" warning and suggest the specific `IncludedPaths`.

### 2. RU Evaluation & Logging
- **Real-time RU Tracking**: Every Cosmos DB operation must be wrapped in a telemetry handler that captures the `RequestCharge` from the `ResponseHeader`.
- **Logging**: Log the following for every request:
    - `Request_ID`
    - `Operation_Name` (e.g., "GetUserProfile")
    - `Request_Charge` (RU)
    - `Execution_Time_Ms`
    - `Partition_Key_Value`
- **Cost Analysis**: Use these logs to generate a "Cost per Feature" report. Identify "Heavy Queries" (high RU/low frequency) for refactoring.

### 3. Implementation Guidelines
- **Point Reads**: Always prefer `ReadItemAsync` by ID and Partition Key for single records.
- **Connection Management**: Use a singleton `CosmosClient` instance to avoid socket exhaustion.
- **Azure CLI**:
    - Use `az cosmosdb sql database create` and `az cosmosdb sql container create` for infrastructure-as-code.
    - Use `az cosmosdb sql query` for debugging and manual verification.
- **Error Handling**: Implement retry logic specifically for `429` (Too Many Requests) and `408` (Request Timeout) statuses.
