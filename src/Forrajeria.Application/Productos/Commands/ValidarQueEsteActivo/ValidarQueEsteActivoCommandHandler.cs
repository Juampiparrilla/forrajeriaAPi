using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Productos.Commands.ValidarQueEsteActivo
{
    public class ValidarQueEsteActivoCommandHandler : IRequestHandler<ValidarQueEsteActivoCommand, Unit>
    {
        private readonly IProductoRepository _productoRepository;

        public ValidarQueEsteActivoCommandHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<Unit> Handle(ValidarQueEsteActivoCommand command, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetByIdAsync(command.Id, cancellationToken);
            if (producto == null)
            {
                throw new Exception($"El producto con ID {command.Id} no existe.");
            }

            producto.ValidarQueEsteActivo();

            return Unit.Value;
        }
    }
}
