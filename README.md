# .Net 6, Dapper and SQL Server with Docker (en-us)

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

---



# .Net 6, Dapper, and SQL Server com Docker (pt-br)

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


