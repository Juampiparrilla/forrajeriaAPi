using Forrajeria.Application.Productos.Commands.ActivarProducto;
using Forrajeria.Application.Productos.Commands.CrearProducto;
using Forrajeria.Application.Productos.Commands.DesactivarProducto;
using Forrajeria.Application.Productos.Commands.EditarProducto;
using Forrajeria.Application.Productos.Queries.ListarProductos;
using Forrajeria.Application.Productos.Queries.ObtenerProductoPorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forrajeria.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CrearProductoCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarProductos(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListarProductosQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerProductsPorId(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObtenerProductoPorIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Editar(int id, EditarProductoRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new EditarProductoCommand(id, request.Nombre), cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/desactivar")]
        public async Task<IActionResult> DesactivarProducto(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DesactivarProductoCommand(id), cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/activar")]
        public async Task<IActionResult> ActivarProducto(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ActivarProductoCommand(id), cancellationToken);
            return NoContent();
        }   
    }
}
