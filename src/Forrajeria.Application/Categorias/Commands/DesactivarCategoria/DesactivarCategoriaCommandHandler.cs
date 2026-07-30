using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.Categorias.Commands.DesactivarCategoria
{
    public class DesactivarCategoriaCommandHandler : IRequestHandler<DesactivarCategoriaCommand, Unit>  
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DesactivarCategoriaCommandHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DesactivarCategoriaCommand command, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(command.Id, cancellationToken);
            if (categoria == null)
            {
                throw new NotFoundException($"La categoría con ID {command.Id} no existe.");
            }
            categoria.Desactivar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
