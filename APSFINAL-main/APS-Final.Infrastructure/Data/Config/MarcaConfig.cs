using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APS_Final.Domain.Entities;

namespace APS_Final.Infrastructure.Data.Config
{
    public class MarcaConfig : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            // Define o Nome como obrigatório e com tamanho máximo
            builder.Property(m => m.Nome).IsRequired().HasMaxLength(100);

            // Relacionamento 1:N (Marca tem muitos Modelos)
            builder.HasMany(m => m.Modelos) // Marca tem muitos Modelos
                   .WithOne(mo => mo.Marca)  // Modelo tem uma Marca
                   .HasForeignKey(mo => mo.MarcaId); // A chave estrangeira explícita está em Modelo.MarcaId
        }
    }
}