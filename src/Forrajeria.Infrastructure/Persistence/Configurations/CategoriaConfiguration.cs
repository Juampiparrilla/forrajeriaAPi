using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forrajeria.Infrastructure.Persistence.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categorias");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(c => c.Nombre)
                .IsUnique();

            builder.Property(c => c.Activo)
                .HasColumnName("activo")
                .IsRequired();
        }
    }
}
