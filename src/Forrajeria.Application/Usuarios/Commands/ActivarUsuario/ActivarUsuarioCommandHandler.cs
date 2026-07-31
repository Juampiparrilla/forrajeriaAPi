using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.Usuarios.Commands.ActivarUsuario
{
    public class ActivarUsuarioCommandHandler : IRequestHandler<ActivarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ActivarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(ActivarUsuarioCommand command, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(command.Id, cancellationToken);
            if (usuario == null)
            {
                throw new NotFoundException($"El usuario con ID {command.Id} no existe.");
            }

            usuario.Activar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
