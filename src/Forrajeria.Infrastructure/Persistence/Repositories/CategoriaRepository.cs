using Forrajeria.Application.Categorias.Commands.EditCategoria;
using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forrajeria.Infrastructure.Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ForrajeriaDbContext _context;

        public CategoriaRepository(ForrajeriaDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Categoria categoria, CancellationToken cancellationToken = default)
        {
            if (categoria is null)
                throw new ArgumentNullException(nameof(categoria));

            await _context.Categorias.AddAsync(categoria, cancellationToken);
        }       
        public async Task<List<Categoria>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Categorias
                            .AsNoTracking()
                            .ToListAsync(cancellationToken);
        }

        public Task<Categoria?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Categorias                
                 .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public Task<Categoria?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Categorias
                 .AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }        
    }
}
