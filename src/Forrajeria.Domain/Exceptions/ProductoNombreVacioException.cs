namespace Forrajeria.Domain.Exceptions
{
    public class ProductoNombreVacioException : Exception
    {
        public ProductoNombreVacioException() : base("El nombre del producto no puede estar vacio. ")
        {
        }

        public ProductoNombreVacioException(string message) : base(message)
        {
        }
    }
}
