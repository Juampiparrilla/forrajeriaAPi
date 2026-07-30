using Forrajeria.Domain.Enums;
using MediatR;

namespace Forrajeria.Application.Usuarios.Commands.CrearUsuario
{
    public record CrearUsuarioCommand(String Nombre, String Email, String Password, Roles Rol) : IRequest<CrearUsuarioResponse>
    {
    }

}
