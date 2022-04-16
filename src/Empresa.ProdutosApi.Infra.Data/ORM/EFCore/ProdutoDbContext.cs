using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Empresa.ProdutosApi.Infra.Data.ORM.EFCore
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions options)
            : base(options) { }
        //=>
        //        this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Mostra o script SQL no console
            optionsBuilder.UseLoggerFactory(loggerFactory: LoggerFactory.Create(x =>
                x.AddConsole()
            ));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Busca por todas as Classes que implementam IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoDbContext).Assembly);

        }
    }
}
