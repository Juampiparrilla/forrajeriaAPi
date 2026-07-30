using MediatR;

namespace Forrajeria.Application.Usuarios.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;
}
