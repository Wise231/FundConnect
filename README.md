# FundConnect

A .NET 10 ASP.NET Core MVC starter application for business funding discovery and application management.

## Included in this starter
- Five-project solution structure (Domain, Application, Infrastructure, Web, Tests)
- ASP.NET Core Identity registration, login, logout and role seeding
- SQL Server / LocalDB Entity Framework Core setup
- Funding opportunity directory and details
- Business profile creation
- Funding application submission
- Initial funding-match scoring service and unit tests
- Responsive dark interface

## Requirements
- Visual Studio Community with the ASP.NET and web development workload
- .NET 10 SDK
- SQL Server LocalDB (included with some Visual Studio installations) or SQL Server Express
- Internet access for initial NuGet package restore

## Open and run
1. Extract the ZIP.
2. Open `FundConnect.slnx` in Visual Studio 2022 17.14 or later with .NET 10 support.
3. Set `FundConnect.Web` as the startup project.
4. Confirm LocalDB is installed. The default connection string uses `(localdb)\MSSQLLocalDB`.
5. Build the solution and run `FundConnect.Web`.

If LocalDB is not installed, install SQL Server Express or the SQL Server Express LocalDB feature and update `ConnectionStrings:DefaultConnection` in `FundConnect.Web/appsettings.json`.

## First-run database setup
The app is configured to apply EF Core migrations at startup. Create the initial migration from the solution folder using:

```powershell
dotnet tool install --global dotnet-ef --version 10.0.0
dotnet ef migrations add InitialCreate --project FundConnect.Infrastructure --startup-project FundConnect.Web --output-dir Data/Migrations
dotnet ef database update --project FundConnect.Infrastructure --startup-project FundConnect.Web
```

Then run the web project. If the database does not yet exist, the startup migration call will create it.

## Important limitations
This is a foundation, not a production-ready funding service. Seeded opportunities are fictional examples. The matching engine is a transparent demonstration and is not a legal or financial eligibility decision. Before public deployment, add verified funding data sources, document upload malware scanning and storage, email confirmation and password reset, anti-abuse controls, privacy notices, application status history, admin workflows, comprehensive validation, audit policies, logging/monitoring, backups and security review.

Never commit real credentials, connection secrets, personal information or real business documents to GitHub.
