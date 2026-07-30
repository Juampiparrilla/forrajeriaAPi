using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class DetalleVacioException : BusinessRuleException
    {
        public DetalleVacioException() : base("Para realizar una venta tiene que existir un detalle.")
        {
        }
        public DetalleVacioException(string message) : base(message)
        {
        }
    }
}
