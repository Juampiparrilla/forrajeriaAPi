using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.Conflict
{
    public class ProductoInactivoException : ConflictException
    {
        public ProductoInactivoException() : base("El producto se encuentra inactivo.")
        {
        }

        public ProductoInactivoException(string message) : base(message)
        {
        }
    }
}
