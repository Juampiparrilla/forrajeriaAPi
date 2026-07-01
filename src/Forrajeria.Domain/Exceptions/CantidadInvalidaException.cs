namespace Forrajeria.Domain.Exceptions
{
    public class CantidadInvalidaException : Exception
    {
        public CantidadInvalidaException() : base("Ingrese una cantidad valida")
        {
        }

        public CantidadInvalidaException(string message) : base(message)
        {
        }
    }
}
