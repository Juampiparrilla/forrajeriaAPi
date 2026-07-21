using Forrajeria.Application.Categorias.Queries.ListarCategorias;
using Forrajeria.Application.Interfaces;

namespace Forrajeria.Application.Categorias.Queries.ObtenerCategoriaPorId
{
    public class ObtenerCategoriaPorIdHandler
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public ObtenerCategoriaPorIdHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<ListarCategoriasResponse> Handle(int id, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsNoTrackingAsync(id, cancellationToken);
            
            if (categoria == null)
            {
                throw new Exception($"No se encontró la categoría con ID {id}");
            }

            return new ListarCategoriasResponse(
                categoria.Id,
                categoria.Nombre,
                categoria.Activo
            );           
        }
    }
}
