# Используем .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY *.sln .
COPY AmazonKillerBack/*.csproj ./AmazonKillerBack/
RUN dotnet restore

# Копируем остальной код
COPY AmazonKillerBack/. ./AmazonKillerBack/
WORKDIR /app/AmazonKillerBack

# Собираем
RUN dotnet publish -c Release -o out

# Используем рантайм
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/AmazonKillerBack/out ./

ENTRYPOINT ["dotnet", "AmazonKillerBack.dll"]
