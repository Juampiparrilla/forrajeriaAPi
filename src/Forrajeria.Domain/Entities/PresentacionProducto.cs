using Forrajeria.Domain.Enums;
using Forrajeria.Domain.Exceptions.BusinessRules;

namespace Forrajeria.Domain.Entities
{
    public class PresentacionProducto
    {
        private readonly List<DetalleVenta> _detallesVenta = new();
        public IReadOnlyCollection<DetalleVenta> DetallesVenta => _detallesVenta;
        public int Id { get; private set; }
        public int ProductoId { get; private set; }
        public Producto Producto { get; private set; }
        public UnidadMedida UnidadMedida { get; private set; }
        public decimal CantidadUnidad { get; private set; }
        public decimal PrecioCompra { get; private set; }
        public decimal MargenGanancia { get; private set; }
        public decimal PrecioVenta => PrecioCompra * (1 + MargenGanancia / 100);
        public string DescripcionPresentacion => $"{Producto.Nombre} - {CantidadUnidad} {UnidadMedida}";

        protected PresentacionProducto()
        {
            
        }
        public PresentacionProducto(Producto producto, UnidadMedida unidadMedida, decimal cantidadUnidad, decimal precioCompra, decimal margenGanancia)
        {
            ValidarProducto(producto);
            ValidarUnidadMedida(unidadMedida);
            ValidarCantidad(cantidadUnidad);
            ValidarPrecioCompra(precioCompra);
            ValidarMargen(margenGanancia);

            Producto = producto;     
            UnidadMedida = unidadMedida;
            CantidadUnidad = cantidadUnidad;
            PrecioCompra = precioCompra;
            MargenGanancia = margenGanancia;
        }

        private static void ValidarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ProductoVacioException();
            }
        }
        private static void ValidarUnidadMedida(UnidadMedida unidad)
        {
            if (!Enum.IsDefined(unidad))
                throw new UnidadMedidaException();
        }
        private static void ValidarCantidad(decimal cantidad)
        {
            if (cantidad <= 0)
                throw new CantidadInvalidaException();
        }

        private static void ValidarPrecioCompra(decimal precio)
        {
            if (precio < 0)
                throw new PrecioInvalidoException();
        }

        private static void ValidarMargen(decimal margen)
        {
            if (margen < 0)
                throw new MargenGananciaInvalidoException();
        }

        public void ModificarPrecioCompra(decimal nuevoPrecio)
        {
            ValidarPrecioCompra(nuevoPrecio);
            PrecioCompra = nuevoPrecio;
        }

        public void ModificarMargenGanancia(decimal nuevoMargen)
        {
            ValidarMargen(nuevoMargen);
            MargenGanancia = nuevoMargen;
        }
    }
}