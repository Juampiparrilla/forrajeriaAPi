using Forrajeria.Domain.Enums;
using MediatR;

namespace Forrajeria.Application.PresentacionesProductos.Commands.CrearPresentacionProducto
{
    public record CrearPresentacionProductoCommand(
        int ProductoId,
        UnidadMedida UnidadMedida,
        decimal CantidadUnidad,
        decimal PrecioCompra,
        decimal MargenGanancia) : IRequest<CrearPresentacionProductoResponse>
    {
    }
}
