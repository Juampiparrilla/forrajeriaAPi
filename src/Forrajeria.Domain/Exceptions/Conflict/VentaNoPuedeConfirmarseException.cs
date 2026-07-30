using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.Conflict
{
    public class VentaNoPuedeConfirmarseException : ConflictException
    {
        public VentaNoPuedeConfirmarseException() : base("La venta ya ha sido confirmada.")
        {
        }
        public VentaNoPuedeConfirmarseException(string message) : base(message)
        {
        }
    }
}
