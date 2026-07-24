using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.PresentacionesProductos.Commands.EditarPresentacionProducto
{
    public class EditarPresentacionProductoCommandHandler : IRequestHandler<EditarPresentacionProductoCommand, Unit>
    {
        private readonly IPresentacionProductoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EditarPresentacionProductoCommandHandler(IPresentacionProductoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EditarPresentacionProductoCommand command, CancellationToken cancellationToken)
        {
            var presentacionProducto = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (presentacionProducto == null)
            {
                throw new Exception($"La presentación de producto con ID {command.Id} no existe.");
            }

            presentacionProducto.ModificarPrecioCompra(command.PrecioCompra);
            presentacionProducto.ModificarMargenGanancia(command.MargenGanancia);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
