# AmazonKillerBack

Backend for Amazon Killer app written in ASP.NET Core 9.0 with Clean Architecture, Vertical Slice pattern, and PostgreSQL support.

---

## ✅ Features
- ASP.NET Core 9.0 Web API
- PostgreSQL with EF Core and code-first migrations
- Docker + docker-compose support
- Vertical Slice Architecture (MediatR)
- FluentValidation for input validation
- AutoMapper for mapping entities to DTOs
- OpenAPI/Swagger UI for API documentation and testing

---

## 🚀 Getting Started

### Requirements
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker](https://www.docker.com/products/docker-desktop)

### Run with Docker
```bash
docker-compose up --build
```

This will:
- Build the backend using the provided `Dockerfile`
- Start PostgreSQL with preconfigured credentials
- Apply EF Core migrations automatically on startup

App will be available at:
- Scalar: [http://localhost:8080/scalar](http://localhost:8080/swagger)
- API: [http://localhost:8080/api/Product](http://localhost:8080/api/Product)

---

## 📁 Project Structure
```
AmazonKiller/
├── AmazonKiller.Domain/
├── AmazonKiller.Application/
├── AmazonKiller.Infrastructure/
└── AmazonKiller.WebApi/

```

---

## 🛠 API Endpoints
- `GET /api/Product` – Get all products
- `POST /api/Product` – Create a new product

### Example Payload for `POST`
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

### Run manually
```bash
dotnet build
cd AmazonKillerBack
ASPNETCORE_ENVIRONMENT=Development dotnet run
```

App will launch on:
```
http://localhost:5011
```

### EF Core Migrations
```bash
dotnet ef migrations add MigrationName -s AmazonKillerBack
```

---

## 👤 Author
