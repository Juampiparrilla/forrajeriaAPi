using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Exceptions.Common;
using MediatR;

namespace Forrajeria.Application.Usuarios.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUsuarioRepository usuarioRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (usuario == null || !_passwordHasher.Verify(request.Password, usuario.PasswordHash))
            {
                throw new UnauthorizedException("Email o contraseña inválidos.");
            }

            if (!usuario.Activo)
            {
                throw new BusinessRuleException("El usuario está inactivo.");
            }

            var token = _jwtProvider.GenerarToken(usuario);

            return new LoginResponse(token, usuario.Id, usuario.Nombre, usuario.Email, usuario.Rol);
        }
    }
}
