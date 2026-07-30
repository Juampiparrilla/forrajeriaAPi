namespace Forrajeria.Domain.Exceptions
{
    public class PasswordUsuarioException : Exception
    {
        public PasswordUsuarioException() : base("La contraseña del usuario no puede estar vacía.")
        {
        }
        public PasswordUsuarioException(string message) : base(message)
        {
        }
    }
}
