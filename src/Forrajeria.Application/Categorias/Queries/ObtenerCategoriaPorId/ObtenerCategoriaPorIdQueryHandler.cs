using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Categorias.Queries.ObtenerCategoriaPorId
{
    public class ObtenerCategoriaPorIdQueryHandler : IRequestHandler<ObtenerCategoriaPorIdQuery, ObtenerCategoriaPorIdResponse>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public ObtenerCategoriaPorIdQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<ObtenerCategoriaPorIdResponse> Handle(ObtenerCategoriaPorIdQuery query, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsNoTrackingAsync(query.Id, cancellationToken);
            
            if (categoria == null)
            {
                throw new Exception($"No se encontró la categoría con ID {query.Id}");
            }

            return new ObtenerCategoriaPorIdResponse(
                categoria.Id,
                categoria.Nombre,
                categoria.Activo
            );           
        }
    }
}
