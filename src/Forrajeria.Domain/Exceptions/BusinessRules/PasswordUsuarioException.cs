using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class PasswordUsuarioException : BusinessRuleException
    {
        public PasswordUsuarioException() : base("La contraseña del usuario no puede estar vacía.")
        {
        }
        public PasswordUsuarioException(string message) : base(message)
        {
        }
    }
}
