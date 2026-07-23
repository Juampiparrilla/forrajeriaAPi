using MediatR;

namespace Forrajeria.Application.Productos.Commands.EditarProducto
{
    public record EditarProductoCommand(int Id, string Nombre) : IRequest<Unit>;

}
