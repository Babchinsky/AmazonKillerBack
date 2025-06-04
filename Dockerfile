# Сборка
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Копируем sln и csproj
COPY AmazonKillerBack.sln ./
COPY AmazonKiller.Application/AmazonKiller.Application.csproj ./AmazonKiller.Application/
COPY AmazonKiller.Domain/AmazonKiller.Domain.csproj ./AmazonKiller.Domain/
COPY AmazonKiller.Infrastructure/AmazonKiller.Infrastructure.csproj ./AmazonKiller.Infrastructure/
COPY AmazonKiller.Shared/AmazonKiller.Shared.csproj ./AmazonKiller.Shared/
COPY AmazonKiller.WebApi/AmazonKiller.WebApi.csproj ./AmazonKiller.WebApi/

# Восстанавливаем зависимости
RUN dotnet restore AmazonKiller.WebApi/AmazonKiller.WebApi.csproj

# Копируем остальной исходный код
COPY . .

# Сборка
WORKDIR /app/AmazonKiller.WebApi
RUN dotnet publish -c Release -o /app/out

# Рантайм
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "AmazonKiller.WebApi.dll"]
