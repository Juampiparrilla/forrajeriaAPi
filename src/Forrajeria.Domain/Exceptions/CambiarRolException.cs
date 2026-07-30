namespace Forrajeria.Domain.Exceptions
{
    public class CambiarRolException : Exception
    {
        public CambiarRolException() : base("No se puede cambiar el rol del usuario.")
        {
        }
        public CambiarRolException(string message) : base(message)
        {
        }
    }
}
