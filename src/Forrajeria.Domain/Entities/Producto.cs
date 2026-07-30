using Forrajeria.Domain.Exceptions.BusinessRules;
using Forrajeria.Domain.Exceptions.Conflict;

namespace Forrajeria.Domain.Entities
{
    public class Producto
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public bool Activo { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        protected Producto()
        {

        }
        public Producto(string nombre, Categoria categoria)
        {
            ValidarNombre(nombre);
            ValidarCategoria(categoria);
            Nombre = nombre;
            Categoria = categoria;
            CategoriaId = categoria.Id;
            Activo = true;
        }
        public void ValidarQueEsteActivo()
        {
            if (!Activo)
                throw new ProductoInactivoException();
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
                throw new ProductoNombreVacioException();
        }

        private static void ValidarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new CategoriaVaciaException();
        }
    }
}
