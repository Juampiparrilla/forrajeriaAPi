using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.Conflict
{
    public class VentaNoModificableException : ConflictException
    {
        public VentaNoModificableException() : base("La venta no puede ser modificada.")
        {
        }
        public VentaNoModificableException(string message) : base(message)
        {
        }
    }
}
