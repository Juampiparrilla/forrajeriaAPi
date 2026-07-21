using Forrajeria.Application.Interfaces;

namespace Forrajeria.Application.Categorias.Commands.DesactivarCategoria
{
    public class DesactivarCategoriaHandler
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DesactivarCategoriaHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
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
            categoria.Desactivar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
