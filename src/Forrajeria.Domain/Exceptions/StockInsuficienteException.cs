namespace Forrajeria.Domain.Exceptions
{
    public class StockInsuficienteException : Exception
    {
        public StockInsuficienteException() : base("El stock actual es insuficiente para realizar la venta.")
        {
        }

        public StockInsuficienteException(string message) : base(message)
        {
        }
    }
}
