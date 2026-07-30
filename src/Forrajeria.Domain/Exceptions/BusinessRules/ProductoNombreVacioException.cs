using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class ProductoNombreVacioException : BusinessRuleException
    {
        public ProductoNombreVacioException() : base("El nombre del producto no puede estar vacio. ")
        {
        }

        public ProductoNombreVacioException(string message) : base(message)
        {
        }
    }
}
