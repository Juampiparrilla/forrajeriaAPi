using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forrajeria.Infrastructure.Persistence.Repositories
{
    public class PresentacionProductoRepository : IPresentacionProductoRepository
    {
        private readonly ForrajeriaDbContext _context;
        public PresentacionProductoRepository(ForrajeriaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PresentacionProducto presentacionProducto, CancellationToken cancellationToken = default)
        {
            if (presentacionProducto is null)
                throw new ArgumentNullException(nameof(presentacionProducto));

            await _context.PresentacionesProductos.AddAsync(presentacionProducto, cancellationToken);
        }

        public async Task<List<PresentacionProducto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.PresentacionesProductos
                  .Include(p => p.Producto)
                  .AsNoTracking()
                  .ToListAsync(cancellationToken);
        }

        public Task<PresentacionProducto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.PresentacionesProductos
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public Task<PresentacionProducto?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.PresentacionesProductos
                .Include(p => p.Producto)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
    }
}
