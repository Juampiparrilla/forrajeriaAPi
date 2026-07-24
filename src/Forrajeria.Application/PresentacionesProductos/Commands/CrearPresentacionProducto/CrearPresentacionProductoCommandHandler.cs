using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using MediatR;

namespace Forrajeria.Application.PresentacionesProductos.Commands.CrearPresentacionProducto
{
    public class CrearPresentacionProductoCommandHandler : IRequestHandler<CrearPresentacionProductoCommand, CrearPresentacionProductoResponse>
    {
        private readonly IPresentacionProductoRepository _repository;
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPresentacionProductoCommandHandler(
            IPresentacionProductoRepository repository,
            IProductoRepository productoRepository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CrearPresentacionProductoResponse> Handle(CrearPresentacionProductoCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var producto = await _productoRepository.GetByIdAsync(command.ProductoId, cancellationToken);
            if (producto == null)
            {
                throw new Exception($"El producto con ID {command.ProductoId} no existe.");
            }

            var presentacionProducto = new PresentacionProducto(
                producto,
                command.UnidadMedida,
                command.CantidadUnidad,
                command.PrecioCompra,
                command.MargenGanancia);

            await _repository.AddAsync(presentacionProducto, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CrearPresentacionProductoResponse(presentacionProducto.Id);
        }
    }
}
