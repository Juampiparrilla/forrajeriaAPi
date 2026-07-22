using MediatR;

namespace Forrajeria.Application.Categorias.Queries.ObtenerCategoriaPorId
{
    public record ObtenerCategoriaPorIdQuery(int Id) : IRequest<ObtenerCategoriaPorIdResponse>
    {       
    }
}
