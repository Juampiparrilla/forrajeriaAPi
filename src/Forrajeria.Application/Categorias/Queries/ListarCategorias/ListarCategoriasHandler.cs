using Forrajeria.Application.Interfaces;

namespace Forrajeria.Application.Categorias.Queries.ListarCategorias
{
    public class ListarCategoriasHandler
    {
        private readonly ICategoriaRepository _repository;
        public ListarCategoriasHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<ListarCategoriasResponse>> Handle(CancellationToken cancellationToken)
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
