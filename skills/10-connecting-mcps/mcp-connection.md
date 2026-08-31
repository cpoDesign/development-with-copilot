# Connecting MCPs

This skill guides the setup and usage of Model Context Protocol (MCP) servers.

## Available MCPs:
- **SQL MCP**: Local SQL Server instance for real-time data validation.
- **CosmosDB MCP**: CosmosDB Emulator for cloud-native data operations.

## Setup:
1. **Podman**: Ensure Podman is running.
2. **Startup Script**: Run `./startup.ps1` to launch the required containers.
3. **Connection**: The agent can use the `sql-db` or `cosmos-db` MCP tools to query the database during the development and testing phases.

## Validation:
- Use MCPs to verify that data inserted via the API is correctly persisted in the database.
- Use MCPs to check index status and RU (Request Units) evaluation in CosmosDB.
