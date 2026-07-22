using MediatR;

namespace Forrajeria.Application.Categorias.Commands.DesactivarCategoria
{
    public record DesactivarCategoriaCommand(int Id) : IRequest<Unit>
    {
    }
}
