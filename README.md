# APIBoleto

Esta API foi desenvolvida em .NET 6 utilizando o Entity Framework Core como ORM e PostgreSQL como banco de dados. Ela permite o cadastro de Boletos e Bancos, além de consultar registros de forma simples.

A documentação interativa da API é disponibilizada pelo Swagger, facilitando testes de endpoints.

# Tecnologias Utilizadas

- .NET 6

- Entity Framework Core

- PostgreSQL

- Swagger (OpenAPI)

- C#

# Como configurar e executar o projeto:

- Clonar ou baixar o projeto
- Utilizando o Postgre, crie um banco de dados chamado APIBoleto (ou outro nome de sua preferência)
- Configure a connection string no appsettings.json
- Aplique as migrations existentes para criar as tabelas
- Rodar a API
- Utilize o Swagger para consultar: URL do Swagger (http://localhost:5000/swagger)

# Estrutura de Entidades
## Banco

- Representa os bancos disponíveis para cadastro de boletos.

## Propriedades:

- Id (obrigatório): Identificador único do banco.

- Nome (obrigatório): Nome do banco.

- Codigo (obrigatório): Código do banco.

- PercentualJuros (obrigatório): Percentual de juros aplicado aos boletos vencidos.

## Boleto

- Representa os boletos a serem pagos ou recebidos.

## Propriedades:

- Id (obrigatório): Identificador único do boleto.

- NomePagador (obrigatório)

- CpfCnpjPagador (obrigatório)

- NomeBeneficiario (obrigatório)

- CpfCnpjBeneficiario (obrigatório)

- Valor (obrigatório)

- DataVencimento (obrigatório)


# Endpoints
## Banco

- POST /api/banco
Cadastra um novo banco.

- GET /api/banco
Retorna todos os bancos cadastrados.

- GET /api/banco/{codigo}
Retorna um banco específico pelo código.

## Boleto

- POST /api/boleto
Cadastra um novo boleto. Todos os campos obrigatórios devem ser preenchidos.

GET /api/boleto/{id}
Retorna um boleto pelo seu ID.

Caso o boleto esteja vencido, o valor retornado será acrescido do percentual de juros do banco correspondente.
