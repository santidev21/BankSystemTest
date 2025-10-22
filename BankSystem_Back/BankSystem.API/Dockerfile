# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files first
COPY ["BankSystem.API/BankSystem.API.csproj", "BankSystem.API/"]
COPY ["BankSystem.Application/BankSystem.Application.csproj", "BankSystem.Application/"]
COPY ["BankSystem.Domain/BankSystem.Domain.csproj", "BankSystem.Domain/"]
COPY ["BankSystem.Infrastructure/BankSystem.Infrastructure.csproj", "BankSystem.Infrastructure/"]

RUN dotnet restore "BankSystem.API/BankSystem.API.csproj"

# Copy everything
COPY . .
WORKDIR /src/BankSystem.API

RUN dotnet publish -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Expose the internal port
EXPOSE 8080

# Use HTTP only
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "BankSystem.API.dll"]
