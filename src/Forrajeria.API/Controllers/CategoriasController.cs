using Forrajeria.API.Authorization;
using Forrajeria.Application.Categorias.Commands;
using Forrajeria.Application.Categorias.Commands.ActivarCategoria;
using Forrajeria.Application.Categorias.Commands.DesactivarCategoria;
using Forrajeria.Application.Categorias.Commands.EditCategoria;
using Forrajeria.Application.Categorias.Queries.ListarCategorias;
using Forrajeria.Application.Categorias.Queries.ObtenerCategoriaPorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forrajeria.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = Policies.PuedeGestionarCategorias)]
        public async Task<IActionResult> Crear(CrearCategoriaCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Policy = Policies.PuedeVerCategorias)]
        public async Task<IActionResult> ListarCategorias(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListarCategoriasQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = Policies.PuedeVerCategorias)]
        public async Task<IActionResult> ObtenerCategoriaPorId(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObtenerCategoriaPorIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = Policies.PuedeGestionarCategorias)]
        public async Task<IActionResult> EditarCategoria(int id, EditarCategoriaRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new EditarCategoriaCommand(id, request.Nombre), cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/desactivar")]
        [Authorize(Policy = Policies.PuedeGestionarCategorias)]
        public async Task<IActionResult> DesactivarCategoria(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DesactivarCategoriaCommand(id), cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/activar")]
        [Authorize(Policy = Policies.PuedeGestionarCategorias)]
        public async Task<IActionResult> ActivarCategoria(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ActivarCategoriaCommand(id), cancellationToken);
            return NoContent();
        }
    }
}