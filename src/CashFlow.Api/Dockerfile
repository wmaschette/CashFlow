FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CashFlow.Api/CashFlow.Api.csproj", "src/CashFlow.Api/"]
RUN dotnet restore "src/CashFlow.Api/CashFlow.Api.csproj"
COPY . .
WORKDIR "/src/src/CashFlow.Api"
RUN dotnet build "CashFlow.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CashFlow.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]
