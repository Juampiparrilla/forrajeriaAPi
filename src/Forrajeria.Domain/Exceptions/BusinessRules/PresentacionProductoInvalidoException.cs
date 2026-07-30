using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class PresentacionProductoInvalidoException : BusinessRuleException
    {
        public PresentacionProductoInvalidoException() : base("La presentación del producto es inválida.")
        {
        }
        public PresentacionProductoInvalidoException(string message) : base(message)
        {
        }
    }
}
