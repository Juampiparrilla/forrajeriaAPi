using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class CategoriaVaciaException : BusinessRuleException
    {
        public CategoriaVaciaException() : base("La categoría no puede estar vacía.")
        {
        }

        public CategoriaVaciaException(string message) : base(message)
        {
        }
    }
}
