using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApiTarefas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ApiTarefas.Data
{
    public class TarefaDbContext : IdentityDbContext<IdentityUser>
    {
        public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefa => Set<Tarefa>();

    }
}
