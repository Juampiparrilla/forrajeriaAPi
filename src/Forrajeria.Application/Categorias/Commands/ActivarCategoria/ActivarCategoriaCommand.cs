using MediatR;

namespace Forrajeria.Application.Categorias.Commands.ActivarCategoria
{
    public record ActivarCategoriaCommand(int Id) : IRequest<Unit>
    {
    }
}
