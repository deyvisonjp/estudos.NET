using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComReact.Model;

namespace WebComReact.Configuracao
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            // Caso não exista a base ele cria
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produto { get; set; }

    }
}
