using Forrajeria.Domain.Enums;

namespace Forrajeria.Application.Usuarios.Queries.ListarUsuarios
{
    public record ListarUsuariosResponse(int Id, string Nombre, string Email, Roles Rol, bool Activo)
    {
    }
}
