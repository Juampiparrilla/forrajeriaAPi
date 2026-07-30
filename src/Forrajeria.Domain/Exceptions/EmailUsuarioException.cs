namespace Forrajeria.Domain.Exceptions
{
    public class EmailUsuarioException : Exception
    {
        public EmailUsuarioException() : base("El email del usuario no puede estar vacío.")
        {
        }
        public EmailUsuarioException(string message) : base(message)
        {
        }   
    }
}
