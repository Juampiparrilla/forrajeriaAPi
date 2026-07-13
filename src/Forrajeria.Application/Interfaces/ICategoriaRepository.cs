using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Interfaces
{
    public interface ICategoriaRepository
    {
        Task AddAsync(Categoria categoria, CancellationToken cancellationToken = default);
    }
}
