namespace Forrajeria.Domain.Exceptions.Common
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("No autorizado.")
        {
        }
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
