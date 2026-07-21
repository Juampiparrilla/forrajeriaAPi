using Forrajeria.Application.Interfaces;

namespace Forrajeria.Application.Categorias.Commands.ActivarCategoria
{
    public class ActivarCategoriaHandler
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ActivarCategoriaHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(int id, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id, cancellationToken);
            if (categoria == null)
            {
                throw new Exception($"La categoría con ID {id} no existe.");
            }
            categoria.Activar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
