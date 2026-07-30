using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class MargenGananciaInvalidoException : BusinessRuleException
    {
        public MargenGananciaInvalidoException() : base("El margen de ganancia debe ser mayor o igual a cero.")
        {
        }

        public MargenGananciaInvalidoException(string message)
            : base(message)
        {
        }
    }
}
