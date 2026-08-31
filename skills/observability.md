# Skill: Observability & Telemetry
## Core Competencies
- **Distributed Tracing**: Implementation of OpenTelemetry standards to trace requests across multi-layer boundaries (Web -> Service -> Infrastructure).
- **Structured Logging**: Mandatory use of structured logging (e.g., Serilog) to capture Context (UserId, CorrelationId, OperationName, Timestamp).
- **Metrics**: Capture key performance indicators (KPIs) for high-frequency operations.
- **Health Checks**: Implement standard .NET Health Checks for all infrastructure dependencies (SQL, CosmosDB, Redis).

## Implementation Guidelines
- **Telemetry Decorators**: Prefer using Decorators or Middleware to inject observability into existing services without polluting business logic.
- **Log Enrichment**: Ensure every log entry includes the `CorrelationId`.
- **Error Handling**: Differentiate between "Expected" (Domain) errors and "Unexpected" (System) exceptions.
- **Performance Logging**: Log execution time and resource usage (e.g., RU cost for CosmosDB, Row count for SQL).
