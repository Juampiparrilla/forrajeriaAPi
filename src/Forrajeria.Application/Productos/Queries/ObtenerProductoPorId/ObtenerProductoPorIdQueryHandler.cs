using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Productos.Queries.ObtenerProductoPorId
{
    public class ObtenerProductoPorIdQueryHandler : IRequestHandler<ObtenerProductoPorIdQuery, ObtenerProductoPorIdResponse>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerProductoPorIdQueryHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ObtenerProductoPorIdResponse> Handle(ObtenerProductoPorIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var producto = await _productoRepository.GetByIdAsNoTrackingAsync(query.Id, cancellationToken);   
           
            return new ObtenerProductoPorIdResponse(
                producto?.Id ?? 0,
                producto?.Nombre ?? string.Empty,
                producto?.Activo ?? false,
                producto?.CategoriaId ?? 0,
                producto?.Categoria?.Nombre ?? string.Empty
            );

        }
    }
}
