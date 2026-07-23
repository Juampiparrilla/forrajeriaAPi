using MediatR;  

namespace Forrajeria.Application.Productos.Commands.CrearProducto
{
    public record CrearProductoCommand(string Nombre) : IRequest<CrearProductoResponse>
    {
    }
}
