# Project Architecture

## Overview
This project follows a **Vertical Slice Architecture** combined with **Domain-Driven Design (DDD)** principles.

## Layers
### 1. Features (Vertical Slices)
Each folder under `src/Features` represents a specific business capability. A slice contains everything needed to fulfill a request:
- Request Models / DTOs
- Handlers / Logic
- Validators
- Local Unit Tests

### 2. Domain
The core of the application. This is the "Shared Memory Context".
- **Entities**: Complex objects with identity.
- **Value Objects**: Objects defined by attributes (e.g., Money, Address).
- **Domain Services**: Logic that doesn't naturally fit in an entity.

### 3. Infrastructure
Implementation details that are external to the core logic:
- Database Contexts (EF Core).
- External API Clients (HttpClient wrappers).
- Message Bus publishers/subscribers.
- File System access.

### 4. WebApi
The transport layer. Maps HTTP requests to Feature Handlers.

## Development Workflow
1. **Requirement**: Identify the feature.
2. **ADR**: If the feature requires a new shared domain concept, create an ADR.
3. **Implementation**: Build the slice in `src/Features`.
4. **Verification**: Run tests and ensure `.editorconfig` compliance.
5. **Doc Update**: Update `docs/GUIDE.md` and architecture diagrams.
