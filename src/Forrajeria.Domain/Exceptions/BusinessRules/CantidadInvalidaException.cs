using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class CantidadInvalidaException : BusinessRuleException
    {
        public CantidadInvalidaException() : base("La cantidad ingresada es inválida. Debe ser un número positivo mayor a cero.")
        {
        }
        public CantidadInvalidaException(string message) : base(message)
        {
        }
    }
}
