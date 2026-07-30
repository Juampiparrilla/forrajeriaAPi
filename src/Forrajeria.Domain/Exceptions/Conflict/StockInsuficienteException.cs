using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.Domain.Exceptions.Conflict
{
    public class StockInsuficienteException : ConflictException
    {
        public StockInsuficienteException() : base("El stock actual es insuficiente para realizar la venta.")
        {
        }

        public StockInsuficienteException(string message) : base(message)
        {
        }
    }
}
