namespace Forrajeria.Domain.Exceptions
{
    public class DetalleVacioException : Exception
    {
        public DetalleVacioException() : base("Para realizar una venta tiene que existir un detalle.")
        {
        }
        public DetalleVacioException(string message) : base(message)
        {
        }
    }
}
