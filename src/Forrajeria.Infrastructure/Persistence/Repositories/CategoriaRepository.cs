using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;

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
    }
}
