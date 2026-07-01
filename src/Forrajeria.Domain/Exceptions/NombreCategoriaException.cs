namespace Forrajeria.Domain.Exceptions
{
    public class NombreCategoriaException : Exception
    {
        public NombreCategoriaException() : base("El nombre de la categoría no puede estar vacío.")
        {
        }
        public NombreCategoriaException(string message) : base(message)
        {
        }
    }
}
