using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Productos.Commands.ActivarProducto
{
    public class ActivarProductoCommandHandler : IRequestHandler<ActivarProductoCommand, Unit>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivarProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ActivarProductoCommand command, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetByIdAsync(command.Id, cancellationToken);
            if (producto == null)
            {
                throw new Exception($"El producto con ID {command.Id} no existe.");
            }

            producto.Activar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
