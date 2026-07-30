using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forrajeria.Infrastructure.Persistence.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ForrajeriaDbContext _context;
        public VentaRepository(ForrajeriaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Venta venta, CancellationToken cancellationToken = default)
        {
            if (venta is null)
                throw new ArgumentNullException(nameof(venta));

            await _context.Ventas.AddAsync(venta, cancellationToken);
        }

        public async Task<List<Venta>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Ventas
                  .Include(v => v.Detalles)
                  .AsNoTracking()
                  .ToListAsync(cancellationToken);
        }

        public Task<Venta?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Ventas
                .Include(v => v.Detalles)
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

        public Task<Venta?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Ventas
                .Include(v => v.Detalles)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }
    }
}
