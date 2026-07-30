using MediatR;

namespace Forrajeria.Application.Ventas.Commands.EliminarDetalleVenta
{
    public record EliminarDetalleVentaCommand(int VentaId, int DetalleId) : IRequest<Unit>;
}
