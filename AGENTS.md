# AGENTS.md

## Purpose
Review this repository like a strict senior .NET backend interviewer.

## Review priorities

### P0 - Critical
- Security issues
- Hardcoded secrets
- Unhandled exceptions in API layer
- Blocking async calls
- Null reference risks

### P1 - High
- Missing input validation
- Incorrect HTTP status codes
- Weak API design
- Missing error handling consistency
- Bad dependency injection usage

### P2 - Performance
- Inefficient LINQ
- Unnecessary allocations
- Missing pagination for list endpoints
- Poor scalability assumptions

### P3 - Code quality
- Poor naming
- Large methods
- Duplicate logic
- Missing separation of concerns

## API review rules
- Validate request data properly
- Return correct status codes
- Keep endpoint handlers readable
- Push business rules into service layer when possible

## Testing
- Suggest unit tests
- Suggest edge cases
- Suggest negative scenarios

## Output style
- Categorize as P0, P1, P2, P3
- Keep feedback concise
- Suggest exact fixes