# Repository for Udemy course: Maestría en .NET 8 y C#: Proyectos Esenciales
## Introduction

This solution is a collection of five projects and a library built with .NET 8 and C#.
It's designed to demonstrate various functionalities including Database connection to MSSQL, MySQL, PostgreSQL, and SQLite, and MicroServices routing using Ocelot Gateway.
The solution is composed of **MSSQL**, **MySQL**, **PostgreSQL**, and **SQLite** projects for database interaction, **Data** as a library to be consumed by the projects, and finally **OcelotGateway** to route the database MicroServices.

## Projects Overview
### MSSQL
Example of an API connected to Microsoft SQL Server database engine with CRUD functionality using Entity Framework Core.

### MySQL
Example of an API connected to MySQL database engine with CRUD functionality using Entity Framework Core.

### PostgreSQL
Example of an API connected to PostgreSQL database engine with CRUD functionality using Entity Framework Core.

### SQLite
Example of an API connected to SQLite database engine with CRUD functionality using Entity Framework Core.

### OcelotGateway
Example of a gateway using Ocelot package to route different MicroServices.

### Data
Example of a library to have code to reuse on different projects, including an AplicationContext, a BaseEntity model and a BaseController with CRUD functionality.


## Getting Started
### Prerequisites
.NET 8 and 6 SDK
Visual Studio 2022

#### Installation
1. Clone the repository:
2. Open the solution in Visual Studio.
3. Configure the desired project as a StartUp project.
4. Run using IIS Express.

#### Usage

Run each project from Visual Studio to have an idea of how everything works.
You can copy the Data library files to any project to have a BaseController with standard CRUD functionality.
Remember to have a BaseEntity model and to have every other model inherit from this BaseEntity.


#### Configuration

Each project has its configuration settings in the respective appsettings.json file. You can modify these settings according to your requirements.

#### License

This project is licensed under the MIT License.
