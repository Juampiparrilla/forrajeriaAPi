using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forrajeria.Infrastructure.Configurations;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("detalles_venta");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.DescripcionPresentacion)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.CantidadAVender)
            .HasPrecision(10, 2);

        builder.Property(d => d.PrecioUnitario)
            .HasPrecision(10, 2);
    }
}