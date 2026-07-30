using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class PrecioInvalidoException : BusinessRuleException
    {
        public PrecioInvalidoException() : base("El precio ingresado es inválido. Debe ser un valor mayor o igual a cero.")
        {
        }

        public PrecioInvalidoException(string message) : base(message)
        {
        }
    }
}
