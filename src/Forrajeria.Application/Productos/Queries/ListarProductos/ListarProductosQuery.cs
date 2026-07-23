using MediatR;

namespace Forrajeria.Application.Productos.Queries.ListarProductos
{
    public record ListarProductosQuery : IRequest<List<ListarProductosResponse>>
    {
    }
}
