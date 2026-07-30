using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class DescuentoNegativoException : BusinessRuleException
    {
        public DescuentoNegativoException() : base("El descuento no puede ser negativo.")
        {
        }
        public DescuentoNegativoException(string message) : base(message)
        {
        }
    }
}
