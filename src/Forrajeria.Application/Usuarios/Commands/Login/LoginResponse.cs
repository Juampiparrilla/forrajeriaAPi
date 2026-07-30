using Forrajeria.Domain.Enums;

namespace Forrajeria.Application.Usuarios.Commands.Login
{
    public record LoginResponse(string Token, int UsuarioId, string Nombre, string Email, Roles Rol)
    {
    }
}
