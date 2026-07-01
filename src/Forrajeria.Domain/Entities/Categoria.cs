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
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new NombreCategoriaException();
            }
            Nombre = nombre;
            Activo = true; // Se crea como activo por defecto   
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
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                throw new NombreCategoriaException();
            }
            Nombre = nuevoNombre;
        }
    }
}
