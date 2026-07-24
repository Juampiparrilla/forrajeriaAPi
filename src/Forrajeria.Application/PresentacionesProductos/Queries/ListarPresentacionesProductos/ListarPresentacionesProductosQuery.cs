using MediatR;

namespace Forrajeria.Application.PresentacionesProductos.Queries.ListarPresentacionesProductos
{
    public record ListarPresentacionesProductosQuery : IRequest<List<ListarPresentacionesProductosResponse>>
    {
    }
}
