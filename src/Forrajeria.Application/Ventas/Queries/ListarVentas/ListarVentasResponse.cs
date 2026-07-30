using Forrajeria.Domain.Enums;

namespace Forrajeria.Application.Ventas.Queries.ListarVentas
{
    public record ListarVentasResponse(
        int Id,
        DateTime FechaCreacion,
        EstadoVenta Estado,
        decimal Descuento,
        decimal Total,
        int CantidadDetalles)
    {
    }
}
