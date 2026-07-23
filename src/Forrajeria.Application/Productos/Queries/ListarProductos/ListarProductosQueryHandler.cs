using Forrajeria.Application.Categorias.Queries.ListarCategorias;
using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using MediatR;

namespace Forrajeria.Application.Productos.Queries.ListarProductos
{
    public class ListarProductosQueryHandler : IRequestHandler<ListarProductosQuery, List<ListarProductosResponse>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ListarProductosQueryHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ListarProductosResponse>> Handle(ListarProductosQuery request, CancellationToken cancellationToken)
        {
            var ListaProductos = await _productoRepository.GetAllAsync(cancellationToken);

            return ListaProductos.Select(p => new ListarProductosResponse(
                                                            p.Id,
                                                            p.Nombre,
                                                            p.Activo,
                                                            p.CategoriaId,
                                                            p.Categoria?.Nombre ?? string.Empty
                                                        )).ToList();
        }
    }
}
