using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class UnidadMedidaException : BusinessRuleException
    {
        public UnidadMedidaException() : base("La unidad de medida no puede estar vacía.")
        {
        }
        public UnidadMedidaException(string message) : base(message)
        {
        }
    }
}
