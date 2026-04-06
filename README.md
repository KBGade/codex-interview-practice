# Interview Practice App

A simple .NET console application created for interview preparation and Codex-based code review practice.

## Purpose

This repository is used to practice:
- clean C# coding
- Git branching and pull requests
- Codex code review
- algorithm and API interview exercises

## Current Example

The current implementation demonstrates:
- frequency counting with `Dictionary<int, int>`
- sorting with LINQ
- returning top K frequent elements

## Tech Stack

- C#
- .NET
- VS Code
- GitHub
- OpenAI Codex

## Run Locally

```bash
dotnet restore
dotnet run

Future Practice Ideas
Subarray Sum Equals K
Merge Intervals
Number of Islands
REST API with validation and error handling
EF Core query optimization
async/await correctness exercises
Why this repo exists

The goal is to simulate a real engineering workflow:

write code
commit changes
open a PR
get Codex review
improve the code

A clear README helps both humans and tools understand the project. OpenAI’s Codex docs recommend giving Codex clear repo context and persistent instructions; a good README plus `AGENTS.md` is a strong setup. :contentReference[oaicite:4]{index=4}

---

# 6) Add `AGENTS.md` for Codex review behavior

Create `AGENTS.md` in the repo root:

```md
# AGENTS.md

## Purpose
Guide Codex to review this repository like a strict senior .NET interviewer.

## Review guidelines

### Correctness
- Flag null handling issues
- Check boundary conditions and edge cases
- Verify algorithm correctness

### Performance
- Flag inefficient LINQ or repeated enumeration
- Check whether time and space complexity can be improved
- Flag unnecessary allocations where relevant

### C# quality
- Flag poor naming
- Flag large methods that should be split
- Prefer readable and maintainable code over clever code

### Async and API readiness
- Flag blocking calls such as `.Result` or `.Wait()`
- Suggest `CancellationToken` where appropriate
- Flag missing validation or weak error handling

### Security and logging
- Flag secrets, tokens, and unsafe logging
- Flag any sensitive data exposure

### Testing
- Suggest useful unit tests
- Suggest negative and edge-case tests

## Output style
- Group findings by severity
- Keep comments concise
- Suggest concrete fixes