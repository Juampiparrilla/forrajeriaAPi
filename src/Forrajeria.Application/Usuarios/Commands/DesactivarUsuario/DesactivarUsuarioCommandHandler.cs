using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.Usuarios.Commands.DesactivarUsuario
{
    public class DesactivarUsuarioCommandHandler : IRequestHandler<DesactivarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DesactivarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DesactivarUsuarioCommand command, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(command.Id, cancellationToken);
            if (usuario == null)
            {
                throw new NotFoundException($"El usuario con ID {command.Id} no existe.");
            }

            usuario.Desactivar();
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
