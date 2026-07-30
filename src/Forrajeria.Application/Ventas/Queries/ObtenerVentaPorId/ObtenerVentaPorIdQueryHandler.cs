using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Ventas.Queries.ObtenerVentaPorId
{
    public class ObtenerVentaPorIdQueryHandler : IRequestHandler<ObtenerVentaPorIdQuery, ObtenerVentaPorIdResponse>
    {
        private readonly IVentaRepository _repository;

        public ObtenerVentaPorIdQueryHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ObtenerVentaPorIdResponse> Handle(ObtenerVentaPorIdQuery query, CancellationToken cancellationToken)
        {
            var venta = await _repository.GetByIdAsNoTrackingAsync(query.Id, cancellationToken);

            if (venta == null)
            {
                throw new Exception($"No se encontró la venta con ID {query.Id}");
            }

            var detalles = venta.Detalles.Select(d => new DetalleVentaResponse(
                d.Id,
                d.PresentacionProductoId,
                d.DescripcionPresentacion,
                d.CantidadAVender,
                d.PrecioUnitario,
                d.Subtotal
            )).ToList();

            return new ObtenerVentaPorIdResponse(
                venta.Id,
                venta.FechaCreacion,
                venta.FechaConfirmacion,
                venta.FechaCancelacion,
                venta.Estado,
                venta.Descuento,
                venta.Total,
                detalles
            );
        }
    }
}
