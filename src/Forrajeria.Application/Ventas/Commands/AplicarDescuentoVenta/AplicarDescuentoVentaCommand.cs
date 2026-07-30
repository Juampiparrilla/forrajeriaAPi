using MediatR;

namespace Forrajeria.Application.Ventas.Commands.AplicarDescuentoVenta
{
    public record AplicarDescuentoVentaCommand(int Id, decimal Descuento) : IRequest<Unit>;
}
