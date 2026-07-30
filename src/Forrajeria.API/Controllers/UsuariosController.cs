using Microsoft.AspNetCore.Mvc;
using MediatR;
using Forrajeria.Application.Usuarios.Commands.CrearUsuario;
using Forrajeria.Application.Usuarios.Queries.ListarUsuarios;

namespace Forrajeria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CrearUsuarioCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListarUsuariosQuery(), cancellationToken);
            return Ok(response);
        }
    }
}
