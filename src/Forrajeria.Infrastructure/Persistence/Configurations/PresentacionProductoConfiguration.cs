using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forrajeria.Infrastructure.Persistence.Configurations;

public class PresentacionProductoConfiguration
    : IEntityTypeConfiguration<PresentacionProducto>
{
    public void Configure(EntityTypeBuilder<PresentacionProducto> builder)
    {
        builder.ToTable("presentaciones_productos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.CantidadUnidad)
            .HasPrecision(10, 2);

        builder.Property(p => p.PrecioCompra)
            .HasPrecision(10, 2);

        builder.Property(p => p.MargenGanancia)
            .HasPrecision(10, 2);


        builder.HasOne(p => p.Producto)
            .WithMany()
            .HasForeignKey(p => p.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.DetallesVenta)
            .WithOne(d => d.PresentacionProducto)
            .HasForeignKey(d => d.PresentacionProductoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}