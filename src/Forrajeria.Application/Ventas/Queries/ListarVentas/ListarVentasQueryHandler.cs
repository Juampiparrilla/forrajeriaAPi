using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Ventas.Queries.ListarVentas
{
    public class ListarVentasQueryHandler : IRequestHandler<ListarVentasQuery, List<ListarVentasResponse>>
    {
        private readonly IVentaRepository _repository;

        public ListarVentasQueryHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ListarVentasResponse>> Handle(ListarVentasQuery request, CancellationToken cancellationToken)
        {
            var ventas = await _repository.GetAllAsync(cancellationToken);

            return ventas.Select(v => new ListarVentasResponse(
                v.Id,
                v.FechaCreacion,
                v.Estado,
                v.Descuento,
                v.Total,
                v.Detalles.Count
            )).ToList();
        }
    }
}
