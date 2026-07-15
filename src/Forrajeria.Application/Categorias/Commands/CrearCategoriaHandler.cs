using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;

namespace Forrajeria.Application.Categorias.Commands
{
    public class CrearCategoriaHandler
    {
        private readonly ICategoriaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;


        public CrearCategoriaHandler(ICategoriaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CrearCategoriaResponse> Handle(CrearCategoriaCommand command, CancellationToken cancellationToken)
        {
            var categoria = new Categoria(command.Nombre);

            await _repository.AddAsync(categoria, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new CrearCategoriaResponse { Id = categoria.Id };
        }

    }
}



