# AmazonKillerBack

Backend for **Amazon Killer** app written in **ASP.NET Core 9.0**, following **Clean Architecture** and **Vertical Slice
** pattern.

---

## ✅ Features

- ASP.NET Core 9.0 Web API
- **SQL Server** with EF Core and code-first migrations
- Docker + docker-compose support
- Clean Architecture:
    - Domain (Entities, Enums)
    - Application (CQRS, Interfaces, DTOs)
    - Infrastructure (EF Core, Repositories)
    - WebApi (Controllers, Program)
- Vertical Slice Architecture using MediatR
- AutoMapper for object mapping
- FluentValidation for request validation
- Scalar (OpenAPI UI) for API documentation

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker](https://www.docker.com/products/docker-desktop)

---

### Run with Docker

```bash
docker-compose up --build
```

This will:

- Build the backend from `AmazonKiller.WebApi`
- Start **SQL Server** container with default credentials
- Apply EF Core migrations on startup automatically

> The app will be available at:
>
> - Full API documentation via Scalar: [http://localhost:8080/scalar](http://localhost:8080/scalar)
> - Product API base route: [http://localhost:8080/api/products](http://localhost:8080/api/products)

---

## 📁 Project Structure

```
AmazonKillerBack/
├── AmazonKiller.Application/           # CQRS features, DTOs, interfaces, validators
├── AmazonKiller.Domain/                # Domain entities and enums
├── AmazonKiller.Infrastructure/        # EF Core DbContext, repository implementations
├── AmazonKiller.IntegrationTests/      # Integration tests for API endpoints
├── AmazonKiller.Shared/                # Shared code (constants, extensions, helpers)
├── AmazonKiller.WebApi/                # API controllers, Program.cs, Startup logic
```

---

## 🛠 API Endpoints

Here is an example request to create a new **category**:

### POST `/api/categories`

#### Request Body:

```json
{
  "name": "Electronics",
  "parentId": null,
  "description": "All electronic products",
  "imageUrl": "https://example.com/electronics.jpg",
  "iconName": "icon-electronics",
  "propertyKeys": [
    "Brand",
    "Model",
    "Warranty"
  ],
  "status": 0
}
```

#### Sample Response:

```json
{
  "id": "e0b130d1-90df-4cbe-a443-d776a5296e90",
  "name": "Electronics"
}
```

---

## 🧪 Development

### Run manually (without Docker)

```bash
dotnet build
cd AmazonKiller.WebApi
ASPNETCORE_ENVIRONMENT=Development dotnet run
```

The app will launch at:

```
http://localhost:5011
```

---

## 🧪 API Testing

Postman collection and environment files are located in the `Postman/` directory.

To use:

1. Import `Postman/AmazonKiller API.postman_collection_v2.json` into Postman.
2. Import `Postman/AmazonKiller Local.postman_environment.json` as environment.

---

### EF Core Migrations

#### Create a migration

```bash
dotnet ef migrations add MigrationName -p AmazonKiller.Infrastructure -s AmazonKiller.WebApi
```

#### Apply migrations manually

```bash
dotnet ef database update -p AmazonKiller.Infrastructure -s AmazonKiller.WebApi
```

> Migrations are also applied automatically on app startup.

---

## 📦 NuGet Packages Used

| Package                                   | Description                                   |
|-------------------------------------------|-----------------------------------------------|
| `Microsoft.EntityFrameworkCore.SqlServer` | SQL Server provider for EF Core               |
| `MediatR`                                 | Implements the Vertical Slice/CQRS pattern    |
| `FluentValidation`                        | Validation framework for request models       |
| `AutoMapper`                              | Object-to-object mapping                      |
| `Scalar.AspNetCore`                       | OpenAPI documentation UI                      |
| `Microsoft.AspNetCore.OpenApi`            | Native OpenAPI/Swagger integration            |
| `FluentValidation.AspNetCore`             | ASP.NET Core integration for FluentValidation |
| `Microsoft.Extensions.Configuration.*`    | For config, env vars, and JSON support        |
| `Microsoft.AspNetCore.Mvc.NewtonsoftJson` | Optional: for customizing JSON serialization  |

---

## 👤 Authors

**Oleksii Babchynskyi**  
**Bogdan Franchuk**