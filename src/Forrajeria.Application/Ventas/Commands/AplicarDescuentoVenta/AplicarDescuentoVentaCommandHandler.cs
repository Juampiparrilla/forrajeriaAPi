using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Ventas.Commands.AplicarDescuentoVenta
{
    public class AplicarDescuentoVentaCommandHandler : IRequestHandler<AplicarDescuentoVentaCommand, Unit>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AplicarDescuentoVentaCommandHandler(IVentaRepository ventaRepository, IUnitOfWork unitOfWork)
        {
            _ventaRepository = ventaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AplicarDescuentoVentaCommand command, CancellationToken cancellationToken)
        {
            var venta = await _ventaRepository.GetByIdAsync(command.Id, cancellationToken);
            if (venta == null)
            {
                throw new Exception($"La venta con ID {command.Id} no existe.");
            }

            venta.AplicarDescuento(command.Descuento);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
