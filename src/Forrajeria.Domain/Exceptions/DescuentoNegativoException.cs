namespace Forrajeria.Domain.Exceptions
{
    public class DescuentoNegativoException : Exception
    {
        public DescuentoNegativoException() : base("El descuento no puede ser negativo.")
        {
        }
        public DescuentoNegativoException(string message) : base(message)
        {
        }
    }
}
