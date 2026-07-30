using Forrajeria.Application.Ventas.Commands.AgregarDetalleVenta;
using Forrajeria.Application.Ventas.Commands.AplicarDescuentoVenta;
using Forrajeria.Application.Ventas.Commands.CancelarVenta;
using Forrajeria.Application.Ventas.Commands.ConfirmarVenta;
using Forrajeria.Application.Ventas.Commands.CrearVenta;
using Forrajeria.Application.Ventas.Commands.EliminarDetalleVenta;
using Forrajeria.Application.Ventas.Queries.ListarVentas;
using Forrajeria.Application.Ventas.Queries.ObtenerVentaPorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forrajeria.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VentasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CrearVentaCommand(), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarVentas(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListarVentasQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerVentaPorId(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObtenerVentaPorIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost("{id:int}/detalles")]
        public async Task<IActionResult> AgregarDetalle(int id, AgregarDetalleVentaRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AgregarDetalleVentaCommand(id, request.PresentacionProductoId, request.Cantidad), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:int}/detalles/{detalleId:int}")]
        public async Task<IActionResult> EliminarDetalle(int id, int detalleId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new EliminarDetalleVentaCommand(id, detalleId), cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/descuento")]
        public async Task<IActionResult> AplicarDescuento(int id, AplicarDescuentoVentaRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AplicarDescuentoVentaCommand(id, request.Descuento), cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/confirmar")]
        public async Task<IActionResult> Confirmar(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ConfirmarVentaCommand(id), cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/cancelar")]
        public async Task<IActionResult> Cancelar(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CancelarVentaCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
