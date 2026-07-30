using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Ventas.Commands.AgregarDetalleVenta
{
    public class AgregarDetalleVentaCommandHandler : IRequestHandler<AgregarDetalleVentaCommand, Unit>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IPresentacionProductoRepository _presentacionProductoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarDetalleVentaCommandHandler(
            IVentaRepository ventaRepository,
            IPresentacionProductoRepository presentacionProductoRepository,
            IUnitOfWork unitOfWork)
        {
            _ventaRepository = ventaRepository;
            _presentacionProductoRepository = presentacionProductoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AgregarDetalleVentaCommand command, CancellationToken cancellationToken)
        {
            var venta = await _ventaRepository.GetByIdAsync(command.VentaId, cancellationToken);
            if (venta == null)
            {
                throw new Exception($"La venta con ID {command.VentaId} no existe.");
            }

            var presentacionProducto = await _presentacionProductoRepository.GetByIdAsync(command.PresentacionProductoId, cancellationToken);
            if (presentacionProducto == null)
            {
                throw new Exception($"La presentación de producto con ID {command.PresentacionProductoId} no existe.");
            }

            venta.AgregarDetalle(presentacionProducto, command.Cantidad);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
