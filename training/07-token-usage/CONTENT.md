# Module 07: Token Usage

## Overview
LLMs have a limited context window. Every piece of information you add (files, ADRs, skills) consumes "tokens."

## Optimization Strategies
1. **Context Pruning**: Only provide files directly relevant to the current task.
2. **Summary Files**: Use a  for high-level project state instead of feeding in 50 files.
3. **Skill Efficiency**: Keep your custom skill files concise.

## Workable Exercises
- **Exercise 1**: Compare the performance of a query when providing a 100-line file vs. a 500-line file.
- **Exercise 2**: Use a summary of your architecture instead of the entire codebase to see how it affects the AI's "reasoning" quality.
