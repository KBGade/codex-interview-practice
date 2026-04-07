# Codex Interview Practice

A .NET interview practice repository used for coding exercises, API design, pull request reviews, and Codex-based code quality feedback.

## Current Exercise
Minimal ASP.NET Core Web API for order management.

## Features
- Create order
- Get all orders
- Get order by id
- Delete order
- Swagger enabled
- Service layer with basic validation

## Tech Stack
- C#
- ASP.NET Core Web API
- Swagger / OpenAPI
- VS Code
- Git
- GitHub
- Codex review workflow

## Project Structure

```
src/
  InterviewPracticeApi/
tests/
AGENTS.md
README.md
.gitignore
codex-interview-practice.sln
```

## Run locally

```
dotnet restore
dotnet run --project src/InterviewPracticeApi/InterviewPracticeApi.csproj
```

## Endpoints

### GET /
Health-style welcome endpoint

### GET /orders
Returns all orders

### GET /orders/{id}
Returns order by id

### POST /orders
Creates a new order

Example request body:

```
{
  "customerName": "Kiran",
  "productName": "Laptop",
  "amount": 75000
}
```

### DELETE /orders/{id}
Deletes order by id

## Purpose

This repository is for interview preparation using a realistic engineering workflow:
1. build feature  
2. commit code  
3. open pull request  
4. run Codex review  
5. improve code