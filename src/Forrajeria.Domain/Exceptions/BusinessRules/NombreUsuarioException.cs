using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class NombreUsuarioException : BusinessRuleException
    {
        public NombreUsuarioException() : base("El nombre de usuario no puede estar vacío.")
        {
        }
        public NombreUsuarioException(string message) : base(message)
        {
        }
    }
}
