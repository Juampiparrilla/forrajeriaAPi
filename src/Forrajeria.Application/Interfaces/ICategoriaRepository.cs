using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Interfaces
{
    public interface ICategoriaRepository
    {
        Task AddAsync(Categoria categoria, CancellationToken cancellationToken = default);
        Task<List<Categoria>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Categoria?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Categoria?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default);
    }
}
