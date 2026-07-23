namespace Forrajeria.Domain.Exceptions
{
    public class CategoriaVaciaException : Exception
    {
        public CategoriaVaciaException() : base("La categoría no puede estar vacía.")
        {
        }

        public CategoriaVaciaException(string message) : base(message)
        {
        }
    }
}
