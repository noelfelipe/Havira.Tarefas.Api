
# Havira.Tarefas.Api

`Havira.Tarefas.Api` é uma API REST desenvolvida em .NET 6 para gerenciamento de tarefas. Permite aos usuários criar, atualizar, deletar e listar tarefas, além de registrar e autenticar usuários.

## Recursos

- Registro e autenticação de usuários
- CRUD para tarefas:
  - Criação de tarefas
  - Atualização de tarefas
  - Exclusão de tarefas
  - Listagem de tarefas do usuário

## Tecnologias Utilizadas

- ASP.NET Core 6
- Entity Framework Core
- SQL Server
- JWT para autenticação

## Configuração Inicial

Para executar o projeto localmente, siga os passos abaixo:

### Pré-requisitos

- .NET 6 SDK
- SQL Server

### Passos

###Recomendado a utilização de IDE Visual Studio

1. Clone o repositório:
   ```
   git clone https://github.com/noelfelipe/Havira.Tarefas.Api.git
   ```
2. Navegue até a pasta do projeto clonado:
   ```
   cd Havira.Tarefas.Api
   ```
3. Restaure os pacotes NuGet:
   ```
   dotnet restore
   ```
4. Configure a string de conexão no arquivo `appsettings.json` para apontar para o seu SQL Server.

5. Aplique a criação de tabelas Script na pasta: 
   ``` Havira.Tarefas.Api\Havira.Tarefas.Infrastructure\TabelasCreate ```
6. Execute a aplicação:
   ```
   dotnet run
   ```

## Uso

Após iniciar a aplicação, você pode usar as seguintes rotas para interagir com a API:

- `POST /api/Usuarios/register`: registrar um novo usuário.
- `POST /api/Usuarios/login`: autenticar um usuário.

#### Para utilização dos endpoints abaixo é necessario um usuario registrado com os endpoint [registrar um novo usuário] e utilizar o bearer token gerado no endpoint [autenticar um usuário]

- `POST /api/Todos`: cria uma nova tarefa.
- `GET /api/Todos`: lista todas as tarefas do usuário autenticado.
- `PUT /api/Todos/{id}`: atualiza uma tarefa existente.
- `DELETE /api/Todos/{id}`: exclui uma tarefa.

## Licença

Distribuído sob a licença MIT. Veja `LICENSE` para mais informações.

## Contato

Noel Felipe - noelgnn@gmail.com

Link do Projeto: [https://github.com/noelfelipe/Havira.Tarefas.Api](https://github.com/noelfelipe/Havira.Tarefas.Api)
