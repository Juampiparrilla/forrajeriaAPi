using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forrajeria.Infrastructure.Persistence.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("productos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nombre)
            .HasColumnName("nombre")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Activo)
            .HasColumnName("activo")
            .IsRequired();

        builder.HasIndex(p => p.Nombre)
            .IsUnique();
    }
}