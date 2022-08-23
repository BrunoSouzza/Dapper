# .Net 6, Dapper and SQL Server with Docker (en-us)

> **Note**
> This is a simple example

> **Warning**
> This code must not go to PRODUCTION

---

> Install Nuget Packages

In this project we will develop a simple CRUD using .Net 6, Dapper and SQL Server. Let's go :rocket:!

After creating the .NET 6 project, we need to add the nuget package to use Dapper.

Install package using the command below:
```powershell
Install-Package Dapper -Version 2.0.123
```
We also need to install package to connect the SQL Server.
Install package using the command below:
```powershell
Install-Package System.Data.SqlClient -Version 4.8.3
```
> Configure SQL Server (Docker)

To run SQL locally we will use Docker. Note the command below:

* We accept the terms of use: "ACCEPT_EULA=1"
* We set a password for SA: @Bruno@123
* We define the SA user
* Port Bind to port 1433 of the container to port 1433 of our computer

```powershell
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Bruno@123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sqlserver mcr.microsoft.com/ azure-sql-edge
After running the command successfully, we can use a client of our choice to test the connection.
```

> Database creation

Run the command below to create the Database and Table
```sql
GO

CREATE DATABASE Factory

GO

use factory

CREATE TABLE Car (
Id int primary key identity,
Name varchar(max),
int year,
Created at date and time
)

GO

> .Net 6 and Dapper

```
Finally, we will start development using C#. :joy:

We need to add our ConnectionString in appSettings:

```json
{
  "ConnectionStrings": {
    "Factory": "Data Source=::1;Database=Factory;User ID=sa;Password=Bruno@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Let's create a folder called Entities and inside that folder we create a class called "Car". Basically this class should be a mirror of our Database.

```cs
public class car
{
    public int Id { get; to define; }
    public string Name { get; to define; }
    public int Year { get; to define; }
    public DateTime CreatedAt { get; to define; }
}
The next step is the creation of our Controller Car.

dependencies
using Dapper;
using DapperSQLServer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
Class
namespace DapperSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        private read-only string _connectionString;

        public CarController (IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Factory");
        }

        [HttpGet]
        Public async Task<IActionResult> GetCars()
        {
            using var connection = new SqlConnection(_connectionString);
            var cars = await connection.QueryAsync<Car>("select * from Car");

            return Ok(cars);
        }

        [HttpGet("{id}")]
        Public async Task<IActionResult> GetCarById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var car = await connection.QueryFirstAsync<Car>("select * from Car where id = @Id", new { Id = id });
            return Ok(car);
        }

        [HttpPost]
        Public async Task<IActionResult> CreateCar(Car request)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("enter values ​​Car (name, year, createdAt) (@name, @year, @createdAt)", new
            {
                Name = request.Name,
                Year = order.Year,
                CreatedAt = DateTime.UtcNow
            });

            returnOk();
        }

        [HttpPut]
        Public async Task<IActionResult> UpdateCar(Car request)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("update Car set name = @Name, year = @Year", new
            {
                Name = request.Name,
                Year = order.Year
            });

            return Ok(GetCarById(request.Id));
        }

        [HttpDelete("{id}")]
        Public async Task<IActionResult> DeleteCarById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("delete Car where id = @Id", new { Id = id });
            return Ok(GetCars());
        }
    }
}
```

Our simple example is ready ::trophy::

---

# .Net 6, Dapper, and SQL Server com Docker (pt-br)


> **Note**
> Trata-se de um simples exemplo

> **Warning**
> Este código não deve ir para PRODUÇÃO

---
<br>
> Instalando pacotes do Nuget

Neste projeto nós vamos desenvolver um simples CRUD usando .Net 6, Dapper e SQL Server. Vamos lá :rocket:! 

Depois de criando o projeto de API Web .Net 6, precisamos adicionar o pacote do nuget para usar o Dapper. 

Instale o pacote usando o comando abaixo:
```powershell
Install-Package Dapper -Version 2.0.123
```

Precisamos também instalar o pacote para conectar com o SQL Server.ver.
Instale o pacote usando o comando abaixo:
```powershell
Install-Package System.Data.SqlClient -Version 4.8.3
```

> Configurando SQL Server (Docker)

Para rodar o SQL localmente utilizaremos Docker.
Observe o comando abaixo.
* Aceitamos os termos de uso: "ACCEPT_EULA=1"
* Definimos uma senha para SA: "Bruno@123"
* Definimos o PID para Developer
* Definimos o usuário SA
* Porta bind para porta 1433 do container para a porta 1433 do nosso computador. 

```powershell
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Bruno@123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sqlserver mcr.microsoft.com/azure-sql-edge
```

After executar o comando com sucesso, podemos usar um client de nossa preferência para testar a conexão. 

> Criação Bando de Dados

Execute o comando abaixo para criação do Banco de Dados e Tabela.

```sql
GO

CREATE DATABASE Factory

GO

Use Factory

CREATE TABLE Car (
	Id int primary key identity,
	Name varchar(max),
	Year int,
	CreatedAt Datetime
)

GO
```

> .Net 6 e Dapper

Finalmente iniciaremos o desenvolvimento usando C#. :joy:

Precisamos adicionar nossa ConnectionString no appSettings:

```json
{
  "ConnectionStrings": {
    "Factory": "Data Source=::1;Database=Factory;User ID=sa;Password=Bruno@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Vamos criar uma pasta chamada Entities e dentro dessa pasta criamos uma classe chamada "Car". Basicamente essa classe deve ser espelho do nosso Banco de Dados.

```cs
public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

Próximo passo é a criação da nossa Controller Car.

* Dependências
```cs
using Dapper;
using DapperSQLServer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
```
* Classe 
```cs
namespace DapperSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CarController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Factory");
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            using var connection = new SqlConnection(_connectionString);
            var cars = await connection.QueryAsync<Car>("select * from Car");

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var car = await connection.QueryFirstAsync<Car>("select * from Car where id = @Id", new { Id = id });
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(Car request)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("insert into Car (name, year, createdAt) values (@name, @year, @createdAt)", new
            {
                Name = request.Name,
                Year = request.Year,
                CreatedAt = DateTime.UtcNow
            });

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(Car request)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("update Car set name = @Name, year = @Year", new
            {
                Name = request.Name,
                Year = request.Year
            });

            return Ok(GetCarById(request.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("delete Car where id = @Id", new { Id = id });
            return Ok(GetCars());
        }
    }
}
```
Pronto, nosso simples exemplo está pronto. ::trophy:: 
