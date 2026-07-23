using MediatR;

namespace Forrajeria.Application.Productos.Queries.ObtenerProductoPorId
{
    public record  ObtenerProductoPorIdQuery(int Id) : IRequest<ObtenerProductoPorIdResponse>
    {
    }
}
