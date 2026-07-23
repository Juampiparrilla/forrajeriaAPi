using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Interfaces
{
    public interface IProductoRepository
    {
        Task AddAsync(Producto producto, CancellationToken cancellationToken = default);
        Task<List<Producto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Producto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Producto?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default);
    }
}
