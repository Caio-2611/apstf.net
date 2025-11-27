using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APS_Final.Domain.Entities;

namespace APS_Final.Infrastructure.Data.Config
{
    public class ModeloConfig : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.Property(m => m.Nome).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Ano).IsRequired();

            // Define explicitamente a Chave Estrangeira e a obrigatoriedade
            builder.HasOne(m => m.Marca)    // Modelo tem UMA Marca
                   .WithMany(ma => ma.Modelos) // Marca tem MUITOS Modelos
                   .HasForeignKey(m => m.MarcaId) // A FK é a MarcaId
                   .IsRequired(); // Garante que a FK seja NOT NULL (obrigatório)
            
            // Define a chave primária de Modelo explicitamente (embora já seja padrão)
            builder.HasKey(m => m.Id);
        }
    }
}