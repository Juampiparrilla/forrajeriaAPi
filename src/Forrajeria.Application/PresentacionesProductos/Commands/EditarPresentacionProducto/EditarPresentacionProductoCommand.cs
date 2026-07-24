using MediatR;

namespace Forrajeria.Application.PresentacionesProductos.Commands.EditarPresentacionProducto
{
    public record EditarPresentacionProductoCommand(int Id, decimal PrecioCompra, decimal MargenGanancia) : IRequest<Unit>;
}
