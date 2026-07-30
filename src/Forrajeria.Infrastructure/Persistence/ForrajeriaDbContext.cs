using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forrajeria.Infrastructure.Persistence;

public class ForrajeriaDbContext : DbContext
{
    public ForrajeriaDbContext(
        DbContextOptions<ForrajeriaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<PresentacionProducto> PresentacionesProductos => Set<PresentacionProducto>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<DetalleVenta> DetallesVenta => Set<DetalleVenta>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForrajeriaDbContext).Assembly);
    }
}