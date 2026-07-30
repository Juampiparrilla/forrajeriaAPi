using MediatR;

namespace Forrajeria.Application.Usuarios.Queries.ListarUsuarios
{
    public record ListarUsuariosQuery : IRequest<List<ListarUsuariosResponse>>
    {
    }
}
