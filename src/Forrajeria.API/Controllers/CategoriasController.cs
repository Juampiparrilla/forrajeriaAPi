using Forrajeria.Application.Categorias.Commands;
using Forrajeria.Application.Categorias.Commands.ActivarCategoria;
using Forrajeria.Application.Categorias.Commands.CrearCategoria;
using Forrajeria.Application.Categorias.Commands.DesactivarCategoria;
using Forrajeria.Application.Categorias.Commands.EditCategoria;
using Forrajeria.Application.Categorias.Queries.ListarCategorias;
using Forrajeria.Application.Categorias.Queries.ObtenerCategoriaPorId;
using Microsoft.AspNetCore.Mvc;

namespace Forrajeria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CrearCategoriaHandler _handlerCrearCategoria;
        private readonly ListarCategoriasHandler _handlerListaCategoria;
        private readonly ObtenerCategoriaPorIdHandler _handlerObtenerCategoriaPorId;
        private readonly EditarCategoriaHandler _handlerEditarCategoriaHandler;
        private readonly DesactivarCategoriaHandler _handlerDesactivarCategoriaHandler;
        private readonly ActivarCategoriaHandler _handlerActivarCategoriaHandler;

        public CategoriasController(CrearCategoriaHandler handlerCrearCategoria, ListarCategoriasHandler handlerListaCategoria, ObtenerCategoriaPorIdHandler handlerObtenerCategoriaPorId, EditarCategoriaHandler handlerEditarCategoriaHandler, DesactivarCategoriaHandler handlerDesactivarCategoriaHandler,
            ActivarCategoriaHandler handlerActivarCategoriaHandler)
        {
            _handlerCrearCategoria = handlerCrearCategoria;
            _handlerListaCategoria = handlerListaCategoria;
            _handlerObtenerCategoriaPorId = handlerObtenerCategoriaPorId;
            _handlerEditarCategoriaHandler = handlerEditarCategoriaHandler;
            _handlerDesactivarCategoriaHandler = handlerDesactivarCategoriaHandler;
            _handlerActivarCategoriaHandler = handlerActivarCategoriaHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(
            CrearCategoriaCommand command,
            CancellationToken cancellationToken)
        {
            var response = await _handlerCrearCategoria.Handle(
                command,
                cancellationToken);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarCategorias(CancellationToken cancellationToken)
        {
            var response = await _handlerListaCategoria.Handle(cancellationToken);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerCategoriaPorId(int id, CancellationToken cancellationToken)
        {
            var response = await _handlerObtenerCategoriaPorId.Handle(id, cancellationToken);

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditarCategoria(int id, EditarCategoriaRequest request, CancellationToken cancellationToken)
        {
            var command = new EditarCategoriaCommand(id, request.Nombre);
            await _handlerEditarCategoriaHandler.Handle(command, cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/desactivar")]
        public async Task<IActionResult> DesactivarCategoria(int id, CancellationToken cancellationToken)
        {            
            await _handlerDesactivarCategoriaHandler.Handle(id, cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}/activar")]
        public async Task<IActionResult> ActivarCategoria(int id, CancellationToken cancellationToken)
        {
            await _handlerActivarCategoriaHandler.Handle(id, cancellationToken);
            return NoContent();
        }
    }
}