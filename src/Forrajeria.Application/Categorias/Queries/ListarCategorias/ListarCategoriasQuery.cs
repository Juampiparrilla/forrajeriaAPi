using MediatR;
namespace Forrajeria.Application.Categorias.Queries.ListarCategorias
{
    public record ListarCategoriasQuery : IRequest<List<ListarCategoriasResponse>>    
    {
    }
}
