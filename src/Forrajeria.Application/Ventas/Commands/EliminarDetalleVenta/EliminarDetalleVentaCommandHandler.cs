using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Ventas.Commands.EliminarDetalleVenta
{
    public class EliminarDetalleVentaCommandHandler : IRequestHandler<EliminarDetalleVentaCommand, Unit>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarDetalleVentaCommandHandler(IVentaRepository ventaRepository, IUnitOfWork unitOfWork)
        {
            _ventaRepository = ventaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EliminarDetalleVentaCommand command, CancellationToken cancellationToken)
        {
            var venta = await _ventaRepository.GetByIdAsync(command.VentaId, cancellationToken);
            if (venta == null)
            {
                throw new Exception($"La venta con ID {command.VentaId} no existe.");
            }

            venta.EliminarDetalle(command.DetalleId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
