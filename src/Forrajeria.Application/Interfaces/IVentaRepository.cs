using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Interfaces
{
    public interface IVentaRepository
    {
        Task AddAsync(Venta venta, CancellationToken cancellationToken = default);
        Task<List<Venta>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Venta?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Venta?> GetByIdAsNoTrackingAsync(int id, CancellationToken cancellationToken = default);
    }
}
