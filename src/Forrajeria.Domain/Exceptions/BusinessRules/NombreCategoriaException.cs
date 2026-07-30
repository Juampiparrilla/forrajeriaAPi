using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.BusinessRules
{
    public class NombreCategoriaException : BusinessRuleException
    {
        public NombreCategoriaException() : base("El nombre de la categoría no puede estar vacío.")
        {
        }
        public NombreCategoriaException(string message) : base(message)
        {
        }
    }
}
