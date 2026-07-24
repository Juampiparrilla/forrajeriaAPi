using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.PresentacionesProductos.Queries.ListarPresentacionesProductos
{
    public class ListarPresentacionesProductosQueryHandler : IRequestHandler<ListarPresentacionesProductosQuery, List<ListarPresentacionesProductosResponse>>
    {
        private readonly IPresentacionProductoRepository _repository;

        public ListarPresentacionesProductosQueryHandler(IPresentacionProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ListarPresentacionesProductosResponse>> Handle(ListarPresentacionesProductosQuery request, CancellationToken cancellationToken)
        {
            var presentaciones = await _repository.GetAllAsync(cancellationToken);

            return presentaciones.Select(p => new ListarPresentacionesProductosResponse(
                p.Id,
                p.ProductoId,
                p.Producto?.Nombre ?? string.Empty,
                p.UnidadMedida,
                p.CantidadUnidad,
                p.PrecioCompra,
                p.MargenGanancia,
                p.PrecioVenta,
                p.DescripcionPresentacion
            )).ToList();
        }
    }
}
