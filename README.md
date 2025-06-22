Tarefas API
Uma API REST completa para gerenciamento de tarefas, desenvolvida com ASP.NET Core. Este projeto agora inclui funcionalidades de autenticação e autorização baseadas em JWT, permitindo o registro e login de usuários, além de gerenciar tarefas persistidas em SQL Server.

Tecnologias
ASP.NET Core 8.0: Framework para construção de APIs robustas e escaláveis.
Entity Framework Core: ORM para acesso a dados, facilitando a interação com o banco de dados.
SQL Server: Sistema de gerenciamento de banco de dados relacional para persistência de dados.
ASP.NET Core Identity: Sistema de gerenciamento de usuários e perfis para autenticação e autorização.
JWT (JSON Web Tokens): Padrão para criação de tokens de acesso seguro para autenticação de usuários.
Funcionalidades
Gerenciamento de Tarefas:
Criar nova tarefa
Listar todas as tarefas
Atualizar tarefa existente
Deletar tarefa
Autenticação e Autorização de Usuários:
Registro de novos usuários
Login de usuários com geração de token JWT
(Funcionalidade futura: Permissões baseadas em roles para diferentes tipos de usuários)
Como Rodar
Clone o Repositório:

Bash

git clone [URL_DO_SEU_REPOSITORIO]
cd [NOME_DA_SUA_PASTA_DE_PROJETO]
Restaure as Dependências:

Bash

dotnet restore
Configurações do Banco de Dados:

Certifique-se de ter uma instância do SQL Server rodando.
Abra o arquivo appsettings.json (ou appsettings.Development.json) e configure sua string de conexão para o SQL Server em ConnectionStrings:DefaultConnection. Exemplo:
JSON

"ConnectionStrings": {
  "DefaultConnection": "Server=seu_servidor;Database=MinhaApiDeTarefasDb;User Id=seu_usuario;Password=sua_senha;"
}
(Se estiver usando LocalDB, o exemplo atual já serve).
Atualize o Banco de Dados (Migrations):

Bash

dotnet ef database update
Este comando criará o banco de dados e as tabelas necessárias, incluindo as tabelas do Identity para gerenciamento de usuários.

Configure as Chaves JWT:

No mesmo arquivo appsettings.json, preencha a seção JwtSettings com suas chaves e configurações. É crucial usar um Segredo forte e seguro para ambientes de produção.
JSON

"JwtSettings": {
  "Segredo": "SuaChaveSecretaMuitoLongaEComplexaParaSegurancaDoTokenJWT",
  "ExpiracaoHoras": 2,
  "Emissor": "SeuEmissorJWT",
  "Audiencia": "SuaAudienciaJWT"
}
Execute a Aplicação:

Bash

dotnet run
A API estará acessível em https://localhost:XXXX (onde XXXX é a porta configurada).
