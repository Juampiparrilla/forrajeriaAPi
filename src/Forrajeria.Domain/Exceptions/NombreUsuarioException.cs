namespace Forrajeria.Domain.Exceptions
{
    public class NombreUsuarioException : Exception
    {
        public NombreUsuarioException() : base("El nombre de usuario no puede estar vacío.")
        {
        }
        public NombreUsuarioException(string message) : base(message)
        {
        }
    }
}
