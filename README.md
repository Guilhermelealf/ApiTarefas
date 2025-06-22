---
## Tarefas API

Uma API REST para gerenciamento de tarefas, construída com **ASP.NET Core 8.0**. Agora inclui **autenticação de usuários com JWT** e usa **SQL Server** para persistência de dados.

---
### Tecnologias Principais

* **ASP.NET Core 8.0**
* **Entity Framework Core**
* **SQL Server**
* **ASP.NET Core Identity**
* **JWT (JSON Web Tokens)**

---
### Funcionalidades

* **Tarefas:** Criar, Listar, Atualizar, Deletar.
* **Usuários:** Registro, Login (com token JWT).

---
### Como Rodar

1.  **Clone o Repositório:** `git clone [URL]`
2.  **Restaure Dependências:** `dotnet restore`
3.  **Configure `appsettings.json`:**
    * `ConnectionStrings:DefaultConnection` (para SQL Server)
    * `JwtSettings` (com `Segredo`, `ExpiracaoHoras`, `Emissor`, `Audiencia`)
4.  **Atualize o Banco de Dados:** `dotnet ef database update`
5.  **Execute a Aplicação:** `dotnet run`
