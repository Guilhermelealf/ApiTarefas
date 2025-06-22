using Microsoft.EntityFrameworkCore;
using Teste.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Teste.Data
{
    public class TarefaDbContext : IdentityDbContext<IdentityUser>
    {
        public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefa => Set<Tarefa>();

    }
}
