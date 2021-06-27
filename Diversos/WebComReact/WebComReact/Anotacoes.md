# ASP.NET COM REACT

## Passo a passo para criação
1. Projeto AspNet Core com React
2. Criar pasta Model com classe e atributos
3. Criar pasta de Configurações e classe Context.cs
	- Instalar: 
		- Microsoft.EntityFrameworkCore
		- Microsoft.EntityFrameworkCore.SqlServer
4. Configurar na Classe Startup e no appsettings
	-   ```
		"ConnectionStrings": {
			"DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
		},
		```
5. Criar o novo controlador ProdutosController.cs usando APIController