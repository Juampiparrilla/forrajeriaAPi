using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public bool Activo { get; private set; }

        public Categoria(string nombre)
        {
            ValidarNombre(nombre);
            Nombre = nombre;
            Activo = true;  
        }

        public void Activar()
        {
            Activo = true;
        }
        public void Desactivar()
        {
            Activo = false;
        }

        public void ModificarNombre(string nuevoNombre)
        {
            ValidarNombre(nuevoNombre);
            Nombre = nuevoNombre;
        }

        private static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new NombreCategoriaException();
            }
        }

    }
}
