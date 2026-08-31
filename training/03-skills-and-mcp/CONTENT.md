# Module 03: Skills & MCP

## 1. Skills vs. MCP
- **Skills (Rules)**: Static instructions (The "How").
- **MCP (Data)**: Dynamic connections to external systems (The "What").

## 2. The MCP Pipeline
Model Context Protocol (MCP) allows the AI to "see" your local data.
- **SQL MCP**: Provides the AI with read-only query capabilities for the local SQL Server.
- **CosmosDB Emulator**: Allows the AI to interact with a local CosmosDB instance to validate partitioning and RU costs.

## 3. Integration Strategy
When performing a "Data Migration" or "Data Query" task, the AI should:
1. Read the  skill to understand the code patterns.
2. Use the  or  MCP to verify the actual data state.

## 4. Workable Exercises
- **Exercise 1**: Define a local SQL MCP. Ask the AI: "Query the local SQL database for the last 5 orders."
- **Exercise 2**: Use the  skill to ensure the AI uses Dapper for that SQL query instead of EF Core.
