using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.Productos.Commands.DesactivarProducto
{
    public class DesactivarProductoCommandHandler : IRequestHandler<DesactivarProductoCommand, Unit>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DesactivarProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DesactivarProductoCommand command, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetByIdAsync(command.Id, cancellationToken);
            if (producto == null)
            {
                throw new NotFoundException($"El producto con ID {command.Id} no existe.");
            }

            producto.Desactivar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
