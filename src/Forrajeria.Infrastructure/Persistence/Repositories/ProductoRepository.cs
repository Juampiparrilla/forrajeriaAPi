using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forrajeria.Infrastructure.Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ForrajeriaDbContext _context;
        public ProductoRepository(ForrajeriaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Producto producto, CancellationToken cancellationToken = default)
        {
            if (producto is null)
                throw new ArgumentNullException(nameof(producto));

            await _context.Productos.AddAsync(producto, cancellationToken);
        }

        public async Task<List<Producto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Productos
                  .AsNoTracking()
                  .ToListAsync(cancellationToken);
        }
        public Task<Producto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Productos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public Task<Producto?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Productos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

    }
}
