using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class ProductoVacioException : BusinessRuleException
    {
        public ProductoVacioException() : base("Para realizar una venta tiene que existir un producto.")
        {
        }

        public ProductoVacioException(string message) : base(message)
        {
        }
    }
}
