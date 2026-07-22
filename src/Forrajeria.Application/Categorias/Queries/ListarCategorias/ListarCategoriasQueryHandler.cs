using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Categorias.Queries.ListarCategorias
{
    public class ListarCategoriasQueryHandler : IRequestHandler<ListarCategoriasQuery, List<ListarCategoriasResponse>>
    {
        private readonly ICategoriaRepository _repository;
        public ListarCategoriasQueryHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<ListarCategoriasResponse>> Handle(ListarCategoriasQuery query, CancellationToken cancellationToken)
        {
            var categorias = await _repository.GetAllAsync(cancellationToken);

            return categorias
                        .Select(c => new ListarCategoriasResponse(
                            c.Id,
                            c.Nombre,
                            c.Activo))
                        .ToList();
        }
    }
}
