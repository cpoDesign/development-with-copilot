# CosmosDB Emulator MCP Configuration
## Connection Details
- **Endpoint**: `http://localhost:8081`
- **Provider**: Microsoft.Azure.Cosmos
- **Capabilities**:
    - `CreateContainer`: Provision test containers.
    - `UpsertItem`: Seed test data.
    - `QueryData`: Execute read queries for validation.

## Integration
Use this MCP to validate partition key strategies and RU consumption during Module 09 (Testing Loop).
