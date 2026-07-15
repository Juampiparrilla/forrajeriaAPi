using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("ventas");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Descuento)
            .HasPrecision(10, 2);

        builder.HasMany(v => v.Detalles)
            .WithOne()
            .HasForeignKey("VentaId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}