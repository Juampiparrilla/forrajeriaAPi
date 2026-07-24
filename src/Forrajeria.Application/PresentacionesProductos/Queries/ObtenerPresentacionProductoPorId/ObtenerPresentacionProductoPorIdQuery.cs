using MediatR;

namespace Forrajeria.Application.PresentacionesProductos.Queries.ObtenerPresentacionProductoPorId
{
    public record ObtenerPresentacionProductoPorIdQuery(int Id) : IRequest<ObtenerPresentacionProductoPorIdResponse>
    {
    }
}
