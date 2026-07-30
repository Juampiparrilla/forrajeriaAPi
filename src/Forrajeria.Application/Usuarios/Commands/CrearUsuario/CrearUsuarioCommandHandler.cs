using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.Usuarios.Commands.CrearUsuario
{
    public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, CrearUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        public CrearUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }
        public async Task<CrearUsuarioResponse> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var usuarioExistente = await _usuarioRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (usuarioExistente != null)
            {
                throw new ConflictException("Ya existe un usuario registrado con ese email.");
            }

            var passwordHash = _passwordHasher.Hash(request.Password);
            var usuario = new Usuario(request.Nombre, request.Email, passwordHash, request.Rol);

            await _usuarioRepository.AddAsync(usuario, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CrearUsuarioResponse(usuario.Id);
        }
    }
}
