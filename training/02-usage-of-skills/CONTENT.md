# Module 02: Usage of Skills

## 1. How Skills Work
Skills are "Knowledge Modules." When you ask a question related to a skill's description, the agent automatically reads the associated  file to inject expertise.

## 2. Core Skills in this Project
- **Architecture**: Guides the agent on Vertical Slices and ADRs.
- **Security & Contracts**: Enforces input validation and DoS protection.
- **Observability**: Ensures every request has a CorrelationID and is logged.
- **Data Access**: Guides the hybrid use of EF Core and Dapper.

## 3. How to Force a Skill
If the AI seems to be forgetting a rule (e.g., it's not validating a length), explicitly tell it:
> "Apply the guidelines from  to this specific API endpoint."

## 4. Workable Exercises
- **Exercise 1**: Ask the AI to "Create a new Cosmos DB repository." Observe how it pulls in the  skill.
- **Exercise 2**: Ask the AI to "Write a high-performance C# method." Observe how it pulls in  to suggest  or .
