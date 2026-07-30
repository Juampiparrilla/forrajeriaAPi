using MediatR;

namespace Forrajeria.Application.Ventas.Queries.ListarVentas
{
    public record ListarVentasQuery : IRequest<List<ListarVentasResponse>>
    {
    }
}
