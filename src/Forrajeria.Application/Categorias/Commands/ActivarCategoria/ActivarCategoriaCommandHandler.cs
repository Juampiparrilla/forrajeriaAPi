using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Categorias.Commands.ActivarCategoria
{
    public class ActivarCategoriaCommandHandler : IRequestHandler<ActivarCategoriaCommand, Unit>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ActivarCategoriaCommandHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(ActivarCategoriaCommand command, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(command.Id, cancellationToken);
            if (categoria == null)
            {
                throw new Exception($"La categoría con ID {command.Id} no existe.");
            }
            categoria.Activar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
