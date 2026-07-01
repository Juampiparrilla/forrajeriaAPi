namespace Forrajeria.Domain.Exceptions
{
    public class ProductoNombreInvalidoException : Exception
    {
        public ProductoNombreInvalidoException() : base("El nombre del producto no puede estar vacio. ")
        {
        }

        public ProductoNombreInvalidoException(string message) : base(message)
        {
        }
    }
}
