namespace Forrajeria.Domain.Exceptions
{
    public class MargenGananciaInvalidoException : Exception
    {
        public MargenGananciaInvalidoException() : base("El margen de ganancia debe ser mayor o igual a cero.")
        {
        }

        public MargenGananciaInvalidoException(string message)
            : base(message)
        {
        }
    }
}
