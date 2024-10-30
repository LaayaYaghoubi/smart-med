## Medication Management System

### Clean Architecture with ASP.NET
This repository contains an example of a medication management project using Clean Architecture in ASP.NET. It demonstrates the use of the CQRS and Mediator patterns in cqrs branch and service layered in main branch.

To get started with this project:

Clone this repository
Open the solution in Visual Studio or your preferred IDE
Restore the NuGet packages
Run the migration as described in the Project Setup section.
#### Project Setup

Config [migration appsettings.json](src/02.Infrastructure/SmartMed.Migrations/appsettings.json) file according to your SQL Server instance.
Run migration project to create the database.
then make the same changes in the [Rest appsettings.json](src/03.Presentation/SmartMed.RestApi/appsettings.json) file.
Run the project.

#### Project Structure
The project is structured following the principles of Clean Architecture, with separate projects for the Domain, Application, Infrastructure, and Presentation layers.