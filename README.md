# Biblioteca API

API REST simples para gerenciamento de livros, construída com ASP.NET Core, Entity Framework Core e SQL Server.

## Objetivo

O projeto centraliza operações de cadastro e consulta de livros, usando uma estrutura em camadas para separar responsabilidades entre controller, service, repository e acesso a dados.

## Stack

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Scalar/OpenAPI para documentação da API em ambiente de desenvolvimento

## Estrutura do projeto

```text
Biblioteca/
├── Controller/       # Endpoints HTTP
├── Data/             # DbContext e configuração do EF Core
├── DTOs/             # Objetos de entrada e saída
├── Models/           # Entidades de domínio
├── Repositories/     # Acesso a dados
├── Services/         # Regras de negócio
├── Migrations/       # Migrations do banco
└── Program.cs        # Configuração da aplicação
```
