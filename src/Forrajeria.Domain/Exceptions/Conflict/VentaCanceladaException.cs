using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.Conflict
{
    public class VentaCanceladaException : ConflictException
    {
        public VentaCanceladaException() : base("La venta ha sido cancelada.")
        {
        }
        public VentaCanceladaException(string message) : base(message)
        {
        }
    }
}
