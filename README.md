# AmazonKillerBack
Backend for **Amazon Killer** app written in **ASP.NET Core 9.0**, following **Clean Architecture** and **Vertical Slice** pattern.

---

## 🌐 Live Deployment

App is live at:  
🔗 https://amazonkiller-api.greenriver-0a1c5aba.westeurope.azurecontainerapps.io



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
- Azure Container Apps deployment support
- CI/CD via GitHub Actions
- Environment secrets via Azure App Settings

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
├── AmazonKiller.Application/       # CQRS features, DTOs, interfaces, validators
├── AmazonKiller.Domain/            # Domain entities and enums
├── AmazonKiller.Infrastructure/    # EF Core DbContext, repositories, services
├── AmazonKiller.Shared/            # Constants, exceptions, helpers
├── AmazonKiller.WebApi/            # Web API entrypoint, Program.cs, controllers
├── Postman/                        # Postman collection and environments
├── docker-compose.yml              # Local dev environment
└── Dockerfile                      # Docker build for Azure

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

## 🔐 Azure App Configuration & Secrets

When deploying to **Azure Container Apps**, environment variables are injected using **double underscores (`__`)** to
represent nested keys in `appsettings.json`.  
Example mapping:

| appsettings.json Key                  | Azure Env Name                         |
|---------------------------------------|----------------------------------------|
| `Jwt:Key`                             | `Jwt__Key`                             |
| `Stripe:SecretKey`                    | `Stripe__SecretKey`                    |
| `ConnectionStrings:DefaultConnection` | `ConnectionStrings__DefaultConnection` |

Secrets can be configured under the **"Environment Variables"** section of the Container App settings.

---

## 🚀 CI/CD with GitHub Actions

You can automate builds and deployment to Azure Container Registry (ACR):

```yaml
name: Deploy to ACR

on:
  push:
    branches: [main]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3

      - name: Login to Azure Container Registry
        uses: azure/docker-login@v1
        with:
          login-server: amazonkillerregistry.azurecr.io
          username: ${{ secrets.REGISTRY_USERNAME }}
          password: ${{ secrets.REGISTRY_PASSWORD }}

      - name: Build and Push Docker Image
        run: |
          docker build -t amazonkillerregistry.azurecr.io/amazonkiller-api:v1 .
          docker push amazonkillerregistry.azurecr.io/amazonkiller-api:v1
```
---
## 👤 Authors

**Oleksii Babchynskyi**  
**Bogdan Franchuk**