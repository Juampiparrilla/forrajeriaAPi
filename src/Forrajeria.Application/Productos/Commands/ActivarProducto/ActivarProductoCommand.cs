using MediatR;

namespace Forrajeria.Application.Productos.Commands.ActivarProducto
{
    public record ActivarProductoCommand(int Id) : IRequest<Unit>
    {
    }
}
