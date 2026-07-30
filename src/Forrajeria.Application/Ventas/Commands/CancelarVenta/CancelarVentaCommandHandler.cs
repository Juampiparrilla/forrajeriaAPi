using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Ventas.Commands.CancelarVenta
{
    public class CancelarVentaCommandHandler : IRequestHandler<CancelarVentaCommand, Unit>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelarVentaCommandHandler(IVentaRepository ventaRepository, IUnitOfWork unitOfWork)
        {
            _ventaRepository = ventaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CancelarVentaCommand command, CancellationToken cancellationToken)
        {
            var venta = await _ventaRepository.GetByIdAsync(command.Id, cancellationToken);
            if (venta == null)
            {
                throw new Exception($"La venta con ID {command.Id} no existe.");
            }

            venta.Cancelar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
