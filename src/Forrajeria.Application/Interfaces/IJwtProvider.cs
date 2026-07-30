using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerarToken(Usuario usuario);
    }
}
