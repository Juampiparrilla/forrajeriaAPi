using Forrajeria.Domain.Exceptions.BusinessRules;

namespace Forrajeria.Domain.Entities
{
    public class DetalleVenta
    {
        public int Id { get; private set; }
        public int PresentacionProductoId { get; private set; }
        public PresentacionProducto PresentacionProducto { get; private set; }
        public string DescripcionPresentacion { get; private set; }
        public decimal CantidadAVender { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal Subtotal => PrecioUnitario * CantidadAVender;

        protected DetalleVenta()
        {
            
        }
        public DetalleVenta(PresentacionProducto presentacionProducto, decimal cantidadAVender)
        {
            ValidarPresentacionProducto(presentacionProducto);
            ValidarCantidad(cantidadAVender);

            PresentacionProducto = presentacionProducto;
            PresentacionProductoId = presentacionProducto.Id;
            DescripcionPresentacion = presentacionProducto.DescripcionPresentacion;
            PrecioUnitario = presentacionProducto.PrecioVenta;
            CantidadAVender = cantidadAVender;
        }
        private static void ValidarPresentacionProducto(PresentacionProducto presentacionProducto)
        {
            if (presentacionProducto == null)
            {
                throw new PresentacionProductoInvalidoException();
            }
        }

        private static void ValidarCantidad(decimal cantidad)
        {
            if (cantidad <= 0)
                throw new CantidadInvalidaException();
        }
        public void AumentarCantidad(decimal cantidad)
        {
            ValidarCantidad(cantidad);
            CantidadAVender += cantidad;
        }
        public void DisminuirCantidad(decimal cantidad)
        {
            ValidarCantidad(cantidad);

            if (CantidadAVender - cantidad <= 0)
                throw new CantidadInvalidaException();

            CantidadAVender -= cantidad;
        }
    }
}