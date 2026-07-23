using MediatR;

namespace Forrajeria.Application.Productos.Commands.ValidarQueEsteActivo
{
    public record ValidarQueEsteActivoCommand(int Id) : IRequest<Unit>
    {
    }
}
