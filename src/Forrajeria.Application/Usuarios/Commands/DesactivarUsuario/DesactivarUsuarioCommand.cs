using MediatR;

namespace Forrajeria.Application.Usuarios.Commands.DesactivarUsuario
{
    public record DesactivarUsuarioCommand(int Id) : IRequest<Unit>
    {
    }
}
