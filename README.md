<div align="center">

# CSharp: Simple MVC Blockbuster

![.NET Core](https://github.com/jacksjm/csharp-mvc-blockbuster/workflows/.NET%20Core/badge.svg)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)

A mini blockbuster to exemplify the MVC structure on C# (yes likely equal the other repository :sweat:, but better :grimacing:)

</div>

## Run locally

### Prerequisites
- .NET Core

### Steps
1. `dotnet run`

It's a simple console execution :laughing:

<div align="center">
  <img src="./screenshots/menu.png">
</div>

### To use Database
If you like use database, install MariaDB and configure your credentials on `Repositories/Repository.cs`
Is necessary install this steps:
1. `dotnet tool install dotnet-ef -g --version 3.1.1`
2. `dotnet add package Pomelo.EntityFrameworkCore.MySql`
3. `dotnet add package Pomelo.EntityFrameworkCore.MySql.Desing`
4. `dotnet add package Microsoft.EntityFrameworkCore`
5. `dotnet add package Microsoft.EntityFrameworkCore.Desing`
6. `dotnet ef migrations add InitialDB`
7. `dotnet ef database update`

