namespace Forrajeria.Domain.Exceptions.Common
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException() : base("Se ha violado una regla de negocio.")
        {
        }
        public BusinessRuleException(string message) : base(message)
        {
        }
    }
}
