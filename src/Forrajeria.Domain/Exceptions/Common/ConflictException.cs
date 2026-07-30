namespace Forrajeria.Domain.Exceptions.Common
{
    public class ConflictException : Exception
    {
        public ConflictException() : base("Se ha producido un conflicto.")
        {
        }
        public ConflictException(string message) : base(message)
        {
        }
    }
}
