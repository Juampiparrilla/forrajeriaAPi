namespace Forrajeria.Domain.Exceptions
{
    public class VentaNoModificableException : Exception
    {
        public VentaNoModificableException() : base("La venta no puede ser modificada.")
        {
        }
        public VentaNoModificableException(string message) : base(message)
        {
        }
    }
}
