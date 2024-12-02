# Amaggi.Blogger

Amaggi.Blogger é uma aplicação ASP.NET Core para gerenciamento de posts de blog. 
A aplicação utiliza Entity Framework Core com SQLite para persistência de dados e Swagger para documentação da API.
Além disso, suporta WebSockets para notificações em tempo real.

## Funcionalidades

- **CRUD de Posts**: Criação, edição, exclusão e listagem de posts.
- **Notificações em Tempo Real**: Suporte a WebSockets para notificações.
- **Documentação da API**: Documentação interativa com Swagger.

## Estrutura do Projeto

- **Controllers**: Contém os controladores da API.
- **Entities**: Contém as entidades do banco de dados.
- **Notifications**: Contém o serviço de notificações.
- **Services**: Contém os serviços de negócio.

## Configuração

### Pré-requisitos

- .NET 8.0 SDK
- Visual Studio 2022

### Configuração do Banco de Dados

Certifique-se de que a string de conexão `DefaultConnection` esteja configurada corretamente no arquivo `appsettings.json`:

{ "ConnectionStrings": { "DefaultConnection": "Data Source=Data/blog.db" }, "Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning" } }, "AllowedHosts": "*" }

### Executando a Aplicação

1. Abra o projeto no Visual Studio 2022.
2. Compile o projeto para garantir que não há erros de compilação.
3. Execute a aplicação pressionando `F5` ou clicando no botão de "Iniciar Depuração".

### Testando a API

#### Documentação Swagger

1. Quando a aplicação estiver em execução, abra um navegador e navegue até `http://localhost:<porta>/swagger`.
2. Utilize a interface do Swagger para enviar requisições HTTP aos endpoints da API e verificar as respostas.

#### Endpoints da API

- **Criar Post**: `POST /api/Post`
  - Parâmetros: `title`, `content`, `userId`
- **Editar Post**: `PUT /api/Post/{postId}`
  - Parâmetros: `title`, `content`
- **Excluir Post**: `DELETE /api/Post/{postId}`
- **Listar Todos os Posts**: `GET /api/Post`

#### Testando WebSockets

Para testar a funcionalidade de WebSockets, você pode usar uma ferramenta como o `wscat` ou um cliente WebSocket no navegador.

1. Instale o `wscat`:
  npm install -g wscat
2. Conecte-se ao endpoint WebSocket:
  wscat -c ws://localhost:/ws

### Verificando o Banco de Dados

Após executar operações na API, verifique o banco de dados SQLite para garantir que os dados estão sendo persistidos corretamente. Você pode usar uma ferramenta como o `DB Browser for SQLite` para inspecionar o banco de dados.

   
   