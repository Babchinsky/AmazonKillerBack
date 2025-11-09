# Repository Guidelines

## Project Structure & Module Organization
AmazonKillerBack follows Clean Architecture with vertical slices in the `AmazonKiller.Application` project. Keep features self-contained: commands, queries, validators, and profiles live in the same folder. Supporting layers are split into `AmazonKiller.Domain` (entities/enums), `AmazonKiller.Infrastructure` (EF Core, external services), `AmazonKiller.Shared` (cross-cutting helpers), and `AmazonKiller.WebApi` (Program, DI, controllers). Postman artifacts sit in `Postman/`, while container orchestration lives in `Dockerfile` and `docker-compose.yml`.

## Build, Test, and Development Commands
- `dotnet build AmazonKillerBack.sln` — full solution build; use before every push.
- `dotnet run --project AmazonKiller.WebApi` — launches the API on `http://localhost:5011` (honors `ASPNETCORE_ENVIRONMENT`).
- `docker-compose up --build` — spins up WebApi + SQL Server for parity with Azure Container Apps.
- `dotnet ef migrations add <Name> -p AmazonKiller.Infrastructure -s AmazonKiller.WebApi` then `dotnet ef database update ...` — create/apply migrations when schema changes.

## Coding Style & Naming Conventions
Use C# 12 features with file-scoped namespaces, 4-space indentation, and nullable reference types enabled. Favor vertical slice folders (`Products/CreateProduct`) and keep DTOs, handlers, and validators colocated. Classes, records, and public methods use PascalCase; private fields and local variables use camelCase. Prefer expression-bodied members where concise, and run `dotnet format` (or Rider’s Reformat Code) before committing to maintain consistent styling.

## Testing Guidelines
There is no dedicated test project yet; new features should introduce unit or integration tests alongside production code. Name test classes `<Feature>Tests` and methods `<Scenario>_<Expectation>`. Use `dotnet test` to execute the suite once a `tests/` project is added. Until automated coverage exists, keep Postman requests in sync with the `Postman/` collection and document manual verification steps in the PR description.

## Commit & Pull Request Guidelines
Commit history follows Conventional Commits (`feat`, `fix(scope)`, `chore`). Use imperative, present-tense summaries under 72 characters, and include a scope such as `orders` or `startup` when useful. Pull requests must describe the change, reference any Jira/GitHub issue, list breaking changes, and include screenshots or API responses when the behavior affects clients. Ensure CI (build + docker-compose) passes locally before requesting review.

## Security & Configuration Tips
Secrets and connection strings use Azure-style double-underscore keys (e.g., `Jwt__Key`, `ConnectionStrings__DefaultConnection`). Never hardcode credentials; rely on `appsettings.Development.json` locally and environment variables in Container Apps. When sharing sample payloads, scrub PII and rotate keys after demos.
