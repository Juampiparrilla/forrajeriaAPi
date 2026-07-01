namespace Forrajeria.Domain.Exceptions
{
    public class PresentacionProductoInvalidoException : Exception
    {
        public PresentacionProductoInvalidoException() : base("La presentación del producto es inválida.")
        {
        }
        public PresentacionProductoInvalidoException(string message) : base(message)
        {
        }
    }
}
