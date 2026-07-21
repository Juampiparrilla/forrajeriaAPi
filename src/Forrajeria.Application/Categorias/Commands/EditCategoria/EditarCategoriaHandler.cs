using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Categorias.Commands.EditCategoria
{
    public class EditarCategoriaHandler
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EditarCategoriaHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditarCategoriaCommand command, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(command.Id, cancellationToken);
            if (categoria == null)
            {
                throw new Exception($"La categoría con ID {command.Id} no existe.");
            }
            categoria.ModificarNombre(command.Nombre);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
