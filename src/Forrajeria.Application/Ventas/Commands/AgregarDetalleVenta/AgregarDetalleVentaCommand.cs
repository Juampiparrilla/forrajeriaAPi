using MediatR;

namespace Forrajeria.Application.Ventas.Commands.AgregarDetalleVenta
{
    public record AgregarDetalleVentaCommand(int VentaId, int PresentacionProductoId, decimal Cantidad) : IRequest<Unit>;
}
