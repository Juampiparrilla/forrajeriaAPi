using MediatR;

namespace Forrajeria.Application.Productos.Commands.DesactivarProducto
{
    public record DesactivarProductoCommand(int Id) : IRequest<Unit>
    {
    }
}
