# AmazonKillerBack

Backend for **Amazon Killer** app written in **ASP.NET Core 9.0**, following **Clean Architecture** and **Vertical Slice** pattern.

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

- Scalar UI: [http://localhost:8080/scalar](http://localhost:8080/scalar)
- Product API: [http://localhost:8080/api/Product](http://localhost:8080/api/Product)

---

## 📁 Project Structure

```
AmazonKiller/
├── AmazonKiller.Domain/         # Domain entities and enums
├── AmazonKiller.Application/    # CQRS features, DTOs, interfaces, validators
├── AmazonKiller.Infrastructure/ # EF Core DbContext, repository implementations
└── AmazonKiller.WebApi/         # Controllers, Program.cs, API startup logic
```

---

## 🛠 API Endpoints

- `GET /api/Product` – Get all products
- `POST /api/Product` – Create a new product

### Example `POST` Payload

```json
{
  "name": "New Product",
  "description": "Description here",
  "price": 19.99,
  "imageUrl": null,
  "stock": 50,
  "categoryId": "11111111-1111-1111-1111-111111111111"
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

| Package | Description |
|--------|-------------|
| `Microsoft.EntityFrameworkCore.SqlServer` | SQL Server provider for EF Core |
| `MediatR` | Implements the Vertical Slice/CQRS pattern |
| `FluentValidation` | Validation framework for request models |
| `AutoMapper` | Object-to-object mapping |
| `Scalar.AspNetCore` | OpenAPI documentation UI |
| `Microsoft.AspNetCore.OpenApi` | Native OpenAPI/Swagger integration |
| `FluentValidation.AspNetCore` | ASP.NET Core integration for FluentValidation |
| `Microsoft.Extensions.Configuration.*` | For config, env vars, and JSON support |
| `Microsoft.AspNetCore.Mvc.NewtonsoftJson` | Optional: for customizing JSON serialization |

---

## 👤 Authors

**Oleksii Babchynskyi**

**Bogdan Franchuk**

---
