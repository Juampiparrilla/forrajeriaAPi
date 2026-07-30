using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario, CancellationToken cancellationToken = default);
        Task<List<Usuario>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Usuario?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Usuario?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default);
        Task<Usuario?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
