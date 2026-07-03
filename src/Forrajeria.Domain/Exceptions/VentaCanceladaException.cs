namespace Forrajeria.Domain.Exceptions
{
    public class VentaCanceladaException : Exception
    {
        public VentaCanceladaException() : base("La venta ha sido cancelada.")
        {
        }
        public VentaCanceladaException(string message) : base(message)
        {
        }
    }
}
