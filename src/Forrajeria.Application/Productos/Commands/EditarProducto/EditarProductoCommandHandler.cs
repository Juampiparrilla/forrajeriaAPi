using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.Productos.Commands.EditarProducto
{
    public class EditarProductoCommandHandler : IRequestHandler<EditarProductoCommand, Unit>
    {
        private readonly IProductoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EditarProductoCommandHandler(IProductoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(EditarProductoCommand command, CancellationToken cancellationToken)
        {
            var producto = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (producto == null)
            {
                throw new NotFoundException($"El producto con ID {command.Id} no existe.");
            }
            producto.ModificarNombre(command.Nombre);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }       
    }
}
