# SearchPosition Web App

## Api and Data Layers Setup
To setup API and Data layers (ASP.NET Core and SQL Express) you need execute this command in Developer PowerShell:
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
The architecture includes Depenency injection (ASP.NET), ORM (EntityFramework), RestAPI as a gateway via Controllers, Services, Factories and Decarators
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

P.S.
> We can further divide the project into SPA, API, Application, Core, Data, Tests and so on, but I divided it only into API, SPA and Data so as not to make the project difficult to read.

> I created my own tag search for the html file, but I prefer to use HtmlAgilityPack.

> I created my own logging using decorator pattern, but in real project I will use Serilog (For .NET Applications), Prometheus (General Purpose), Application Insights (Azure).

> I haven't added any tests, but I would test the SPA on Angular via Karma because it's already built in and Protractor for UI testing. And I would write tests for the API in Moq using xUnit or NUnit, or in FluentAssertions in the case of BDD.
