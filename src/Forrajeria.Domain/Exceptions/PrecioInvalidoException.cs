namespace Forrajeria.Domain.Exceptions
{
    public class PrecioInvalidoException : Exception
    {
        public PrecioInvalidoException() : base("El precio ingresado es inválido. Debe ser un valor mayor o igual a cero.")
        {
        }

        public PrecioInvalidoException(string message) : base(message)
        {
        }
    }
}
