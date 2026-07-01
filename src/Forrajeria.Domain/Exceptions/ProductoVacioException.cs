namespace Forrajeria.Domain.Exceptions
{
    public class ProductoVacioException : Exception
    {
        public ProductoVacioException() : base("Para realizar una venta tiene que existir un producto.")
        {
        }

        public ProductoVacioException(string message) : base(message)
        {
        }
    }
}
