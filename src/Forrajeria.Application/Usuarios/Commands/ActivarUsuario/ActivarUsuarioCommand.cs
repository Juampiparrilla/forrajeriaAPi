using MediatR;

namespace Forrajeria.Application.Usuarios.Commands.ActivarUsuario
{
    public record ActivarUsuarioCommand(int Id) : IRequest<Unit>
    {
    }
}
