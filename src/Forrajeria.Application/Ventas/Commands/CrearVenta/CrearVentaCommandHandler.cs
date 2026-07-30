using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using MediatR;

namespace Forrajeria.Application.Ventas.Commands.CrearVenta
{
    public class CrearVentaCommandHandler : IRequestHandler<CrearVentaCommand, CrearVentaResponse>
    {
        private readonly IVentaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearVentaCommandHandler(IVentaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CrearVentaResponse> Handle(CrearVentaCommand command, CancellationToken cancellationToken)
        {
            var venta = new Venta();

            await _repository.AddAsync(venta, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CrearVentaResponse(venta.Id);
        }
    }
}
