using Microsoft.EntityFrameworkCore;
using APS_Final.Domain.Entities;
using APS_Final.Infrastructure.Data.Config; // Adicione este using

namespace APS_Final.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets para suas entidades
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica a configuração do relacionamento 1:N
            // Isso garante que o relacionamento 1:N seja explícito, como solicitado.
            modelBuilder.ApplyConfiguration(new MarcaConfig());
            modelBuilder.ApplyConfiguration(new ModeloConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}