using MediatR;

namespace Forrajeria.Application.Ventas.Commands.CancelarVenta
{
    public record CancelarVentaCommand(int Id) : IRequest<Unit>;
}
