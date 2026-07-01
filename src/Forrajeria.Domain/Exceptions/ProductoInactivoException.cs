namespace Forrajeria.Domain.Exceptions
{
    public class ProductoInactivoException : Exception
    {
        public ProductoInactivoException() : base("El producto se encuentra inactivo.")
        {
        }

        public ProductoInactivoException(string message) : base(message)
        {
        }
    }
}
