using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        public DbSet<FilmeLocacao> FilmeLocacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("Server=localhost;User Id=root;Database=blockbuster");
    }
}
