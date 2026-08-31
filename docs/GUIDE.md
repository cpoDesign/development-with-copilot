# Development Guide: AI-Enhanced C# Workflow

This guide outlines how to maximize development efficiency when working with AI agents in this workspace.

## 1. Working with AI Agents
### Contextual Awareness
When starting a task, always provide the AI with the relevant context:
- **Project Architecture**: "Refer to `docs/ARCHITECTURE.md`"
- **Style Rules**: "Adhere to `.editorconfig`"
- **Instructions**: "Follow the rules in `.github/copilot-instructions.md`"

### Prompting Best Practices
- **Chain of Thought**: Ask the AI to "Think step-by-step" and "Explain the architectural implications" before writing code.
- **Interface-First**: Ask the AI to define the interface/DTO first, get your approval, and then ask it to write the implementation.
- **Small Batches**: Request one slice or one method at a time to reduce errors and hallucinations.

## 2. Code Structure & Organization
### Vertical Slice Architecture
Unlike standard N-Tier architecture, we group code by **Feature**. 
- **Parallel Work**: Multiple agents can work on `Features/OrderProcessing` and `Features/UserProfiles` simultaneously with zero risk of merge conflicts in the same files.
- **Shared Context**: If a feature requires a new shared entity, it must be placed in `src/Domain` and discussed via an ADR.

## 3. Quality & Automation
### Style Enforcement
- The project uses `.editorconfig`. 
- Use `dotnet format --verify-no-changes` in CI to ensure no agent deviates from the style.

### Dependency Validation
- Since we are not using ArchUnitNET, the AI agent is responsible for validating architectural boundaries.
- **Rule**: Features should never call other Features directly. They must communicate via Domain services or messages.

### Documentation Loop
1. **Write Code** -> 2. **Create ADR** (if new pattern) -> 3. **Update GUIDE.md** (if new process).

## 4. GitHub Actions Pipeline
Our pipeline ensures the following:
- **Build**: Verification of all projects.
- **Test**: Execution of all unit tests with Coverlet coverage reporting.
- **Lint**: Automatic style checking via `dotnet format`.
- **Static Analysis**: Automated checks for code quality and security.

## 5. Onboarding for New Agents
When a new agent joins this workspace, it should execute the following commands (or have the AI perform them):
1. Read `.github/copilot-instructions.md`.
2. Read `docs/ARCHITECTURE.md`.
3. Scan `docs/ADRs/` to see recent major changes.
