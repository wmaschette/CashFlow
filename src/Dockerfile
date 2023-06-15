# Base image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project files
COPY src/CashFlow.Api/CashFlow.Api.csproj ./src/CashFlow.Api/
COPY src/CashFlow.Tests/CashFlow.Tests.csproj ./src/CashFlow.Tests/

# Restore the project dependencies
RUN dotnet restore src/CashFlow.Api/CashFlow.Api.csproj

# Copy the entire source code to the container
COPY . .

# Build the application
WORKDIR /app/src/CashFlow.Api
RUN dotnet build -c Release --no-restore

# Run the unit tests
WORKDIR /app/src/CashFlow.Tests
RUN dotnet test --no-restore --verbosity normal

# Publish the application
WORKDIR /app/src/CashFlow.Api
RUN dotnet publish -c Release -o /app/publish --no-restore

# Final image for the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose the application port
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]