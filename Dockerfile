# Используем .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Копируем sln и csproj, восстанавливаем зависимости
COPY *.sln .
COPY AmazonKiller.WebApi/*.csproj ./AmazonKiller.WebApi/
RUN dotnet restore ./AmazonKiller.WebApi/AmazonKiller.WebApi.csproj

# Копируем остальной код
COPY . .
WORKDIR /app/AmazonKiller.WebApi

# Публикуем приложение
RUN dotnet publish -c Release -o /app/out

# Используем рантайм
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "AmazonKiller.WebApi.dll"]
