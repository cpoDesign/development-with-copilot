# Module 10: Connecting MCPs

## Overview
Model Context Protocol (MCP) allows Copilot to "see" your local data.

## Local MCP Implementation
- **SQL Local MCP**: Provides the AI with read-only query capabilities for the local SQL Server.
- **CosmosDB Emulator**: Allows the AI to interact with a local CosmosDB instance to validate partitioning and RU costs.

## Workflow
1. **Server Setup**: Run the MCP server (e.g., a .NET console app acting as an MCP host).
2. **Connection**: Connect the MCP server to your local tools.
3. **Querying**: Ask the AI: "Query the local SQL database for the last 5 orders."

## Workable Exercises
- **Exercise 1**: Set up the SQL MCP and ask the AI to "Check the database for errors."
- **Exercise 2**: Use the Cosmos Emulator to "Create a container with a custom partition key."
