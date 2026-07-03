namespace Forrajeria.Domain.Exceptions
{
    public class VentaNoPuedeConfirmarseException : Exception
    {
        public VentaNoPuedeConfirmarseException() : base("La venta ya ha sido confirmada.")
        {
        }
        public VentaNoPuedeConfirmarseException(string message) : base(message)
        {
        }
    }
}
