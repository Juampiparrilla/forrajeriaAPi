using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.Productos.Commands.CrearProducto
{
    public class CrearProductoCommandHandler : IRequestHandler<CrearProductoCommand, CrearProductoResponse>
    {
        private readonly IProductoRepository _repository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearProductoCommandHandler(
            IProductoRepository repository,
            ICategoriaRepository categoriaRepository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CrearProductoResponse> Handle(CrearProductoCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var categoria = await _categoriaRepository.GetByIdAsync(command.CategoriaId, cancellationToken);
            if (categoria == null)
            {
                throw new NotFoundException("La categoría no existe.");
            }

            var producto = new Producto(command.Nombre, categoria);

            await _repository.AddAsync(producto, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CrearProductoResponse(producto.Id);
        }
    }
}
