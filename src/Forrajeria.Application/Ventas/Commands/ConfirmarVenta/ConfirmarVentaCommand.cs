using MediatR;

namespace Forrajeria.Application.Ventas.Commands.ConfirmarVenta
{
    public record ConfirmarVentaCommand(int Id) : IRequest<Unit>;
}
