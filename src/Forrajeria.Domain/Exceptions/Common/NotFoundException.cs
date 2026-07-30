namespace Forrajeria.Domain.Exceptions.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("El recurso solicitado no fue encontrado.")
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
