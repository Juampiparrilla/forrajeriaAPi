using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class EmailUsuarioException : BusinessRuleException
    {
        public EmailUsuarioException() : base("El email del usuario no puede estar vacío.")
        {
        }
        public EmailUsuarioException(string message) : base(message)
        {
        }   
    }
}
