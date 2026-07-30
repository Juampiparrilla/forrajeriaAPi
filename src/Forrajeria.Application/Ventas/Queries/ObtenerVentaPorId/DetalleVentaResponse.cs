namespace Forrajeria.Application.Ventas.Queries.ObtenerVentaPorId
{
    public record DetalleVentaResponse(
        int Id,
        int PresentacionProductoId,
        string DescripcionPresentacion,
        decimal CantidadAVender,
        decimal PrecioUnitario,
        decimal Subtotal)
    {
    }
}
