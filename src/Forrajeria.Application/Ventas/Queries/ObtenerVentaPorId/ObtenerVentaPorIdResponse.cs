using Forrajeria.Domain.Enums;

namespace Forrajeria.Application.Ventas.Queries.ObtenerVentaPorId
{
    public record ObtenerVentaPorIdResponse(
        int Id,
        DateTime FechaCreacion,
        DateTime? FechaConfirmacion,
        DateTime? FechaCancelacion,
        EstadoVenta Estado,
        decimal Descuento,
        decimal Total,
        List<DetalleVentaResponse> Detalles)
    {
    }
}
