using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using MediatR;

namespace Forrajeria.Application.Productos.Commands.CrearProducto
{
    public class CrearProductoCommandHandler : IRequestHandler<CrearProductoCommand, CrearProductoResponse>
    {
        private readonly IProductoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearProductoCommandHandler(IProductoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CrearProductoResponse> Handle(CrearProductoCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var producto = new Producto(command.Nombre);  

            await _repository.AddAsync(producto, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);  

            return new CrearProductoResponse(producto.Id);
        }

      
    }
}
