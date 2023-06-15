# CashFlow

The CashFlow is a personal project in continuous evolution to test and explore new development solutions. It is a financial control application that allows you to record daily entries and obtain consolidated expense reports.

## Features

The CashFlow project offers the following main features through its endpoints:

- **Daily Entry Registration:**
  - `POST /api/dailyentry` - Registers a new daily entry in the system. The request body should include the operation type and the amount.

- **Consolidated Expense Report:**
  - `GET /api/report/consolidated` - Retrieves the consolidated expense report, which includes the operation type and the total amount.

These endpoints allow you to interact with the application, record daily entries, and obtain consolidated information about expenses. Please refer to the API documentation for more details on the required parameters and expected responses for each endpoint.

## Technologies Used

The CashFlow project utilizes the following technologies and tools:

[![Framework](https://img.shields.io/badge/Framework-.NET%207-blueviolet)](https://dotnet.microsoft.com/)
[![Database](https://img.shields.io/badge/Database-PostgreSQL-blue)](https://www.postgresql.org/)
[![Containerization](https://img.shields.io/badge/Containerization-Docker-brightgreen)](https://www.docker.com/)
[![Admin Interface](https://img.shields.io/badge/Admin%20Interface-PgAdmin4-orange)](https://www.pgadmin.org/)
[![Development Environment](https://img.shields.io/badge/Development%20Environment-Visual%20Studio%20Code-blue)](https://code.visualstudio.com/)
[![AI Tool](https://img.shields.io/badge/AI%20Tool-Github%20Copilot-yellow)](https://copilot.github.com/)
[![Chatbot](https://img.shields.io/badge/Chatbot-ChatGPT-brightgreen)](https://www.openai.com/)
[![Testing Framework](https://img.shields.io/badge/Testing%20Framework-XUnit-red)](https://xunit.net/)

These technologies have been chosen to provide a solid and modern foundation for the development of the CashFlow project. The .NET 7 framework is used to create a robust and scalable web application. PostgreSQL is the chosen database, providing performance and advanced features for managing financial data.

The use of Docker allows for the creation of isolated and reproducible environments, making it easier to deploy and run the project on different operating systems. PgAdmin4 is used as the administration interface for the PostgreSQL database, offering management and data visualization features.

Visual Studio Code is the IDE of choice for the development of the CashFlow project, providing a modern, lightweight, and highly customizable programming experience. Github Copilot, an artificial intelligence tool, assists in code writing by offering suggestions and automatically completing code snippets.

To ensure the quality of the project, unit and integration tests are performed using XUnit as the testing framework.

## Used Packages

The CashFlow project utilizes the following NuGet packages to provide additional functionalities and facilitate development:

[![Dapper](https://img.shields.io/badge/Dapper-2.0.123-blue)](https://github.com/StackExchange/Dapper)
- **Dapper** - Version 2.0.123: A high-performance micro-ORM (Object-Relational Mapping) that simplifies database access and manipulation. In the CashFlow project, Dapper is primarily used for querying due to its efficiency and performance.

[![Microsoft.AspNetCore.OpenApi](https://img.shields.io/badge/Microsoft.AspNetCore.OpenApi-7.0.5-blue)](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0.5)
- **Microsoft.AspNetCore.OpenApi** - Version 7.0.5: A package that enables automatic generation of Swagger documentation for the API, facilitating endpoint visualization and testing.

[![Microsoft.EntityFrameworkCore.Tools](https://img.shields.io/badge/Microsoft.EntityFrameworkCore.Tools-7.0.5-blue)](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
- **Microsoft.EntityFrameworkCore.Tools** - Version 7.0.5: A set of tools for Entity Framework Core, including database migration commands and code scaffolding.

[![Npgsql.EntityFrameworkCore.PostgreSQL](https://img.shields.io/badge/Npgsql.EntityFrameworkCore.PostgreSQL-7.0.4-blue)](https://www.npgsql.org/efcore/)
- **Npgsql.EntityFrameworkCore.PostgreSQL** - Version 7.0.4: A PostgreSQL database provider for Entity Framework Core, allowing easy and efficient integration with the database.

[![Swashbuckle.AspNetCore](https://img.shields.io/badge/Swashbuckle.AspNetCore-6.5.0-blue)](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- **Swashbuckle.AspNetCore** - Version 6.5.0: A package that facilitates adding Swagger support to ASP.NET Core applications, providing an interactive documentation interface.

[![Microsoft.NET.Test.Sdk](https://img.shields.io/badge/Microsoft.NET.Test.Sdk-16.11.0-blue)](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/)
- **Microsoft.NET.Test.Sdk** - Version 16.11.0: A package that provides the necessary test framework to run unit tests in .NET. It allows for executing unit tests using the xUnit testing framework.

[![Moq](https://img.shields.io/badge/Moq-4.18.4-blue)](https://www.nuget.org/packages/Moq/)
- **Moq** - Version 4.18.4: An object mocking package for .NET. Moq allows creating object mocks for unit testing, facilitating dependency isolation and the creation of test scenarios.

[![xunit](https://img.shields.io/badge/xunit-2.4.1-blue)](https://www.nuget.org/packages/xunit/)
- **xUnit** - Version 2.4.1: A unit testing framework for .NET. xUnit is a powerful tool for writing and executing unit tests in .NET projects, providing comprehensive features to verify the expected behavior of code. It offers a clean and concise syntax for creating test cases and assertions.

These packages are essential for the development of the CashFlow project, providing additional features, simplifying tasks, and facilitating integration with the PostgreSQL database.

It is important to note that the use of Dapper for querying and Entity Framework Core for CRUD operations is a commonly adopted approach to optimize application performance. Dapper is known for its speed and efficiency in executing simple queries, while Entity Framework Core offers more comprehensive features for entity management and database operations.

The combined use of these two technologies can be a potential performance improvement for the CashFlow project, allowing for more granular control over query operations and optimizing overall application performance.

## Contribution

The CashFlow project is a personal project developed for learning purposes and continuous improvement. At the moment, we are not accepting external contributions. However, we welcome feedback, suggestions, and discussions about the project.

If you have any ideas or suggestions to improve the CashFlow project, feel free to open an issue in our GitHub repository. We will do our best to review and consider your contributions.

For more details, see the Project [Wiki](https://github.com/wmaschette/CashFlow/wiki).

## License

The CashFlow project is distributed under the [MIT License](LICENSE). Feel free to use, modify, and distribute the project according to the terms of the license.

Thank you for using the CashFlow project, and we hope it serves your financial control needs.



