namespace Forrajeria.Domain.Exceptions
{
    public class UnidadMedidaException : Exception
    {
        public UnidadMedidaException() : base("La unidad de medida no puede estar vacía.")
        {
        }
        public UnidadMedidaException(string message) : base(message)
        {
        }
    }
}
