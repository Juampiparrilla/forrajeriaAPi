using Forrajeria.Domain.Enums;

namespace Forrajeria.Application.PresentacionesProductos.Queries.ListarPresentacionesProductos
{
    public record ListarPresentacionesProductosResponse(
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
