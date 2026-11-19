
# FundConnect

### Connecting Businesses to Funding Opportunities

FundConnect is a full-stack web application developed to simplify how businesses discover, evaluate, and apply for funding opportunities.

The platform aims to connect businesses with relevant funding programmes based on their business categories and eligibility requirements, providing a more structured and accessible approach to finding financial support.

## Project Overview

Accessing suitable funding opportunities can be challenging for businesses, particularly when information is scattered across multiple platforms.

FundConnect addresses this challenge by providing a centralised platform where business owners can manage their business profiles, explore funding opportunities, and submit funding applications.

The application is designed with scalability, maintainability, security, and a user-friendly experience in mind.

## Key Features

- **User Authentication:** Registration, login, and secure account management.
- **Role-Based Access Control:** Different permissions for business owners and administrators.
- **Business Profiles:** Capture and manage business information.
- **Funding Directory:** Browse available funding opportunities.
- **Funding Details:** View opportunity requirements and eligibility information.
- **Funding Matching:** Apply structured criteria to identify relevant opportunities.
- **Application Management:** Submit and manage funding applications.
- **Database Integration:** Persist application and business information.

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Core application development |
| .NET 10 | Application framework |
| ASP.NET Core MVC | Web application architecture |
| Entity Framework Core | Object-relational mapping |
| SQL Server | Database management |
| ASP.NET Core Identity | Authentication and authorisation |
| HTML5 | Application structure |
| CSS3 | Styling and responsive design |
| JavaScript | Client-side functionality |
| xUnit | Unit testing |

## Architecture

FundConnect follows a layered architecture to separate responsibilities and improve maintainability.

```text
FundConnect
│
├── FundConnect.Web
│   └── MVC Controllers, Views and UI
│
├── FundConnect.Application
│   └── Application Services and Business Logic
│
├── FundConnect.Domain
│   └── Core Entities and Domain Models
│
├── FundConnect.Infrastructure
│   └── Database and Persistence
│
└── FundConnect.Tests
    └── Unit Tests
```

## Core Development Concepts

This project demonstrates practical application of:

- Object-Oriented Programming (OOP)
- Model-View-Controller (MVC) architecture
- Layered application architecture
- Dependency Injection
- Entity Framework Core
- Database modelling and relationships
- Authentication and authorisation
- Separation of concerns
- Unit testing
- Secure application development principles

## Getting Started

### Prerequisites

Ensure the following tools are installed:

- Visual Studio 2022 or later
- .NET 10 SDK
- SQL Server LocalDB or SQL Server
- Git

### Installation

1. Clone the repository:

```bash
git clone https://github.com/Wise231/FundConnect.git
```

2. Open `FundConnect.slnx` in Visual Studio.

3. Restore NuGet packages:

```bash
dotnet restore FundConnect.slnx
```

4. Configure the database connection in:

`FundConnect.Web/appsettings.json`

5. Create the database migration:

```bash
dotnet ef migrations add InitialCreate --project FundConnect.Infrastructure --startup-project FundConnect.Web --context FundConnectDbContext --output-dir Data/Migrations
```

6. Apply database migrations:

```bash
dotnet ef database update --project FundConnect.Infrastructure --startup-project FundConnect.Web --context FundConnectDbContext
```

7. Build the solution:

```bash
dotnet build FundConnect.slnx
```

8. Run the application:

```bash
dotnet run --project FundConnect.Web
```

## Testing

Run the automated tests using:

```bash
dotnet test FundConnect.slnx
```

## Project Objectives

FundConnect is being developed to demonstrate how modern .NET technologies can be used to solve practical business challenges.

The project focuses on building a maintainable, secure, and scalable platform while demonstrating full-stack development, database integration, application architecture, and software engineering principles.

## Future Enhancements

Potential areas for further development include:

- Advanced funding eligibility algorithms.
- Funding administrator dashboards.
- Document uploads and verification.
- Application status tracking and notifications.
- Funding opportunity management.
- Reporting and analytics.
- External funding data API integrations.

## Developer

**Wise Tshikovhela**

Software Developer | Full-Stack Development | C# | .NET | Java | SQL

GitHub: [Wise231](https://github.com/Wise231)

---

*FundConnect — Making business funding opportunities more accessible.*

Never commit real credentials, connection secrets, personal information or real business documents to GitHub.
