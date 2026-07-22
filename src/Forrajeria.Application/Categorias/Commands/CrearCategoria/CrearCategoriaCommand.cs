using Forrajeria.Application.Categorias.Commands.CrearCategoria;
using MediatR;

namespace Forrajeria.Application.Categorias.Commands
{
    public record CrearCategoriaCommand(string Nombre) : IRequest<CrearCategoriaResponse>;
}
