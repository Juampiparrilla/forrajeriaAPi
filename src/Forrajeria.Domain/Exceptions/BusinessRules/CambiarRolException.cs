using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class CambiarRolException : BusinessRuleException
    {
        public CambiarRolException() : base("No se puede cambiar el rol del usuario.")
        {
        }
        public CambiarRolException(string message) : base(message)
        {
        }
    }
}
