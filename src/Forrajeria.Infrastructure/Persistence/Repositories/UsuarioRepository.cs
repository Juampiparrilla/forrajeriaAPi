using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forrajeria.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ForrajeriaDbContext _context;
        public UsuarioRepository(ForrajeriaDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Usuario usuario, CancellationToken cancellationToken = default)
        {
            if (usuario is null)
                throw new ArgumentNullException(nameof(usuario));

            await _context.Usuarios.AddAsync(usuario, cancellationToken);
        }

        public async Task<List<Usuario>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public Task<Usuario?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public Task<Usuario?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public Task<Usuario?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }
    }
}
