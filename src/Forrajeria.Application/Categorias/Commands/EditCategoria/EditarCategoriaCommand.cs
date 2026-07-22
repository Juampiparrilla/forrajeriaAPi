using MediatR;

namespace Forrajeria.Application.Categorias.Commands.EditCategoria
{
    public record EditarCategoriaCommand(int Id, string Nombre) : IRequest<Unit>;
}
