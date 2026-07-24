# API de Vendas de Joias - Desafio Técnico Timeware

Este projeto foi desenvolvido como parte do desafio técnico para a vaga de Backend da Timeware. Trata-se de uma API REST simples para controle de estoque e registro de vendas de uma joalheria.

## Tecnologias Utilizadas
* C# / .NET 10
* Entity Framework Core (ORM)
* SQLite (Banco de dados embutido)
* xUnit (Testes Unitários)
* ADO.NET (Para consultas SQL puras)

## Arquitetura
O projeto segue uma separação clara de responsabilidades (Clean Architecture simplificada):
* **Domain:** Entidades de negócio (`Joia`, `Venda`).
* **Application:** Regras de negócio e serviços (`VendaService`).
* **Infrastructure:** Acesso a dados e DbContext.
* **Controllers:** Endpoints HTTP.

## Como rodar o projeto

1. Certifique-se de ter o **.NET SDK** instalado em sua máquina.
2. Clone este repositório.
3. Navegue até a pasta raiz do projeto pelo terminal.
4. O banco de dados SQLite (`joalheria.db`) será criado automaticamente ao rodar as migrations. Caso precise aplicar manualmente, use o comando:
   `dotnet ef database update --project TimewareAPI/TimewareAPI.csproj`
5. Para iniciar a API, execute:
   `dotnet run --project TimewareAPI/TimewareAPI.csproj`
6. A API estará acessível em `http://localhost:5290` (ou a porta informada no terminal). 

## Como rodar os testes

Para executar a suíte de testes unitários (que valida a regra de estoque na venda), rode o comando na raiz do projeto:
`dotnet test`