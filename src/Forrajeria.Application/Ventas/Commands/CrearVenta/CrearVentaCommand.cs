using MediatR;

namespace Forrajeria.Application.Ventas.Commands.CrearVenta
{
    public record CrearVentaCommand : IRequest<CrearVentaResponse>
    {
    }
}
