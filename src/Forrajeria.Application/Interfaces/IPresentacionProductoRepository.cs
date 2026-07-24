using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Interfaces
{
    public interface IPresentacionProductoRepository
    {
        Task AddAsync(PresentacionProducto presentacionProducto, CancellationToken cancellationToken = default);
        Task<List<PresentacionProducto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PresentacionProducto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<PresentacionProducto?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default);
    }
}
