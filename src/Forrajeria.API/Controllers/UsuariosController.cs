using Forrajeria.API.Authorization;
using Forrajeria.Application.Usuarios.Commands.CrearUsuario;
using Forrajeria.Application.Usuarios.Commands.Login;
using Forrajeria.Application.Usuarios.Queries.ListarUsuarios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forrajeria.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = Policies.PuedeGestionarUsuarios)]
        public async Task<IActionResult> Crear(CrearUsuarioCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Policy = Policies.PuedeGestionarUsuarios)]
        public async Task<IActionResult> ListarUsuarios(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListarUsuariosQuery(), cancellationToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }       
    }
}
