# SearchPosition Web App

## Api Layer Setup
To setup API layer (ASP.NET Core and SQL Express) you need execute this command in Developer PowerShell:
```console
cd Angular.ASP_SearchPosition.Data
dotnet ef database update --startup-project ../Angular.ASP_SearchPosition.API
cd ../Angular.ASP_SearchPosition.API
dotnet run
```
Make sure you have SQL Server Express installed and have the SearchPosition database.

Swagger can be accessed via http://localhost:5080/swagger

## Spa Layer Setup
To setup SPA layer (Angular) you need execute this command in Developer PowerShell (You need another PowerShell):
```console
cd .\Angular.ASP_SearchPosition.SPA\
npm install
npm start
```

SPA can be accessed via http://localhost:8080/

## Design
The .NET 6 based Web App.

The solution is a N tier Web API that been splitted in 3 layers (Data, API, SPA)
The architecture includes Depenency injection (by default), ORM (EntityFramework), RestAPI as a gateway via Controllers, Services, Factories and Decarators
to provide different behaviour or additional behaviour, Helpers etc.

### Data Layer:
- Technology Stack: Incorporates Entity Framework as the Object-Relational Mapping (ORM) tool.
- Implementation Approach: Utilizes a code-first methodology to facilitate an efficient, developer-oriented environment for database schema creation and management.

### API Layer:
- Foundation: Constructed on ASP.NET Core.
- Design Philosophy: Adheres to RESTful API principles to ensure a standardized, stateless client-server communication protocol.
- Behavior Customization: Utilizes factories and decorators to offer flexibility in extending and customizing application behaviors and functionalities.

### SPA Layer:
- Development Framework: Angular, enabling a dynamic, interactive user interface.
- Interaction Mechanism: Designed for real-time communication with the API layer, ensuring an agile, responsive user engagement experience.
