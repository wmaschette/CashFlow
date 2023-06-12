# Camada base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app

# Restaurar dependências do projeto principal
COPY src/CashFlow.Api/CashFlow.Api.csproj .
RUN dotnet restore

# Copiar e compilar o código do projeto principal
COPY src/CashFlow.Api/ .
RUN dotnet build -c Release -o out

# Executar os testes de unidade
FROM base AS unit-tests
WORKDIR /app/tests/UnitTests

COPY src/CashFlow.Tests/CashFlow.Tests.csproj .
RUN dotnet restore

COPY src/CashFlow.Tests/ .
RUN dotnet test --no-restore --verbosity normal

# Publicar o projeto principal
FROM base AS publish
RUN dotnet publish -c Release -o out

# Camada final para a execução da API principal
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
EXPOSE 80

COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]