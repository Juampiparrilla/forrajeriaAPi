using Forrajeria.API.Authorization;
using Forrajeria.Application.PresentacionesProductos.Commands.CrearPresentacionProducto;
using Forrajeria.Application.PresentacionesProductos.Commands.EditarPresentacionProducto;
using Forrajeria.Application.PresentacionesProductos.Queries.ListarPresentacionesProductos;
using Forrajeria.Application.PresentacionesProductos.Queries.ObtenerPresentacionProductoPorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forrajeria.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PresentacionesProductosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PresentacionesProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = Policies.PuedeGestionarPresentaciones)]
        public async Task<IActionResult> Crear(CrearPresentacionProductoCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Policy = Policies.PuedeVerPresentaciones)]
        public async Task<IActionResult> ListarPresentacionesProductos(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListarPresentacionesProductosQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = Policies.PuedeVerPresentaciones)]
        public async Task<IActionResult> ObtenerPresentacionProductoPorId(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObtenerPresentacionProductoPorIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = Policies.PuedeGestionarPresentaciones)]
        public async Task<IActionResult> EditarPresentacionProducto(int id, EditarPresentacionProductoRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new EditarPresentacionProductoCommand(id, request.PrecioCompra, request.MargenGanancia), cancellationToken);
            return NoContent();
        }
    }
}
