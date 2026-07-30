using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.NotFound
{
    public class DetalleNoEncontradoException : NotFoundException
    {
        public DetalleNoEncontradoException() : base("El detalle no fue encontrado.")
        {
        }
        public DetalleNoEncontradoException(string message) : base(message)
        {
        }
    }
}
