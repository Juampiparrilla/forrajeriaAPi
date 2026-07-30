using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.PresentacionesProductos.Queries.ObtenerPresentacionProductoPorId
{
    public class ObtenerPresentacionProductoPorIdQueryHandler : IRequestHandler<ObtenerPresentacionProductoPorIdQuery, ObtenerPresentacionProductoPorIdResponse>
    {
        private readonly IPresentacionProductoRepository _repository;

        public ObtenerPresentacionProductoPorIdQueryHandler(IPresentacionProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ObtenerPresentacionProductoPorIdResponse> Handle(ObtenerPresentacionProductoPorIdQuery query, CancellationToken cancellationToken)
        {
            var presentacionProducto = await _repository.GetByIdAsNoTrackingAsync(query.Id, cancellationToken);

            if (presentacionProducto == null)
            {
                throw new NotFoundException($"No se encontró la presentación de producto con ID {query.Id}");
            }

            return new ObtenerPresentacionProductoPorIdResponse(
                presentacionProducto.Id,
                presentacionProducto.ProductoId,
                presentacionProducto.Producto?.Nombre ?? string.Empty,
                presentacionProducto.UnidadMedida,
                presentacionProducto.CantidadUnidad,
                presentacionProducto.PrecioCompra,
                presentacionProducto.MargenGanancia,
                presentacionProducto.PrecioVenta,
                presentacionProducto.DescripcionPresentacion
            );
        }
    }
}
