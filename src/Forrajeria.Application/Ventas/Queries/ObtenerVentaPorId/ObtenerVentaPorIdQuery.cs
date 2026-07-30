using MediatR;

namespace Forrajeria.Application.Ventas.Queries.ObtenerVentaPorId
{
    public record ObtenerVentaPorIdQuery(int Id) : IRequest<ObtenerVentaPorIdResponse>
    {
    }
}
