## Project Overview

This project, named SaldoZen, is a financial system designed for personal and business use. It helps users manage their finances by tracking planned versus actual income and expenses. The system supports automatic reconciliation of bank statements, intelligent categorization of transactions, and automation via WhatsApp.

The project follows a Clean Architecture approach, with a clear separation of concerns between the Domain, Application, and Infrastructure layers. It uses the Command Query Responsibility Segregation (CQRS) pattern to separate read and write operations, and the Repository and Unit of Work patterns for data access.

The main technologies used are:

*   **.NET 8:** The core framework for the backend API.
*   **Entity Framework Core and Dapper:** For data access.
*   **PostgreSQL:** As the database.
*   **MediatR:** To implement the CQRS pattern.
*   **JWT:** For authentication.
*   **RabbitMQ:** For asynchronous messaging (not yet fully implemented).
*   **n8n:** For WhatsApp integration and automation.
*   **xUnit:** For unit testing.

The solution is divided into the following projects:

*   **SaldoZen:** The main API project, which exposes the system's functionalities through a RESTful API.
*   **SaldoZen.Domain:** The domain layer, containing the core business logic and entities.
*   **SaldoZen.Aplicacao:** The application layer, which orchestrates the domain logic and implements the CQRS pattern.
*   **SaldoZen.Infraestrutura:** The infrastructure layer, which handles concerns like data access, authentication, and external services.
*   **SaldoZen.McpServer:** A separate server that exposes the application's functionalities to other services, such as the n8n workflow for WhatsApp integration.

## Building and Running

To build and run the project, you will need the .NET 8 SDK and a PostgreSQL database.

1.  **Clone the repository.**
2.  **Configure the database connection:**
    *   Open the `SaldoZen/appsettings.json` file.
    *   Modify the `DefaultConnection` connection string to point to your PostgreSQL database.
3.  **Run the database migrations:**
    *   The application is configured to automatically apply pending migrations on startup.
4.  **Run the main API project:**
    *   You can run the project from your IDE (e.g., Visual Studio, Rider) or by using the following command in the `SaldoZen` directory:
        ```bash
        dotnet run
        ```
5.  **Run the McpServer project:**
    *   You can run the project from your IDE or by using the following command in the `SaldoZen.McpServer` directory:
        ```bash
        dotnet run
        ```

## Development Conventions

*   **Clean Architecture:** The code is organized into layers (Domain, Application, Infrastructure) to ensure a clear separation of concerns.
*   **CQRS:** Commands and queries are used to separate write and read operations.
*   **Repository and Unit of Work:** These patterns are used to abstract the data access logic.
*   **MediatR:** The MediatR library is used to implement the CQRS pattern.
*   **Dependency Injection:** Services are registered and resolved using the built-in .NET dependency injection container.
*   **Testing:** Unit tests are written using xUnit.
*   **API Documentation:** The API is documented using Swagger/OpenAPI. You can access the documentation at `/swagger` when the main API project is running.
