using Forrajeria.Domain.Enums;

namespace Forrajeria.Application.PresentacionesProductos.Queries.ObtenerPresentacionProductoPorId
{
    public record ObtenerPresentacionProductoPorIdResponse(
        int Id,
        int ProductoId,
        string ProductoNombre,
        UnidadMedida UnidadMedida,
        decimal CantidadUnidad,
        decimal PrecioCompra,
        decimal MargenGanancia,
        decimal PrecioVenta,
        string DescripcionPresentacion)
    {
    }
}
