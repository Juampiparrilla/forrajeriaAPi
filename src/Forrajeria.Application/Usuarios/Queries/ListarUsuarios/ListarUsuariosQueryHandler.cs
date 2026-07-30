using Forrajeria.Application.Interfaces;
using MediatR;

namespace Forrajeria.Application.Usuarios.Queries.ListarUsuarios
{
    public class ListarUsuariosQueryHandler : IRequestHandler<ListarUsuariosQuery, List<ListarUsuariosResponse>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ListarUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<ListarUsuariosResponse>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync(cancellationToken);

            return usuarios.Select(u => new ListarUsuariosResponse(
                u.Id,
                u.Nombre,
                u.Email,
                u.Rol,
                u.Activo
            )).ToList();
        }
    }
}
