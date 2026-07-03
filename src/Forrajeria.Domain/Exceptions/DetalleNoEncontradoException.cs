namespace Forrajeria.Domain.Exceptions
{
    public class DetalleNoEncontradoException : Exception
    {
        public DetalleNoEncontradoException() : base("El detalle no fue encontrado.")
        {
        }
        public DetalleNoEncontradoException(string message) : base(message)
        {
        }
    }
}
