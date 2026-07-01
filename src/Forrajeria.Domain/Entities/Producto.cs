using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Entities
{
    public class Producto
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        //public int IdCategoria { get; set; }
        public decimal PrecioVenta { get; private set; }
        public decimal PrecioCompra { get; private set; }
        public int Stock { get; private set; }
        public bool Activo { get; private set; }

        public Producto(string nombre, decimal precioVenta, decimal precioCompra, int stock)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ProductoNombreInvalidoException();
            }

            if (precioVenta < 0 || precioCompra < 0 || stock < 0)
            {
                throw new CantidadInvalidaException();
            }

            Nombre = nombre;
            PrecioVenta = precioVenta;
            PrecioCompra = precioCompra;
            Stock = stock;
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

        public void ModificarPrecioVenta(decimal nuevoPrecio)
        {         
            if (nuevoPrecio < 0)
            {
                throw new PrecioInvalidoException();
            }
            PrecioVenta = nuevoPrecio;
        }
        public void ModificarPrecioCompra(decimal nuevoPrecio)
        {
            if (nuevoPrecio < 0)
            {
                throw new PrecioInvalidoException();
            }
            PrecioCompra = nuevoPrecio;
        }

        public void AumentarStock(int cantidadAIncrementar)
        {
            if (cantidadAIncrementar < 0)
            {
                throw new CantidadInvalidaException(); 
            }
            Stock += cantidadAIncrementar;
        }

        public void ReducirStock(int cantidadVendida)
        {
            if (cantidadVendida < 0)
            {
                throw new CantidadInvalidaException();
            }

            if (Stock - cantidadVendida < 0)
            {
                throw new StockInsuficienteException(); 
            }

            Stock -= cantidadVendida;
        }

        public void ModificarNombre(string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                throw new ProductoNombreInvalidoException(); 
            }
            Nombre = nuevoNombre;
        }
    }
}
