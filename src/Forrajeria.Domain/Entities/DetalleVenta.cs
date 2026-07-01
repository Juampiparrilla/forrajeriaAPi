using Forrajeria.Domain.Exceptions;

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
        private static void ValidarPresentacionProducto(PresentacionProducto producto)
        {
            if (producto == null)
            {
                throw new PresentacionProductoInvalidoException();
            }
        }
       
        private static void ValidarCantidad(decimal cantidad)
        {
            if (cantidad <= 0)
                throw new CantidadInvalidaException();
        }      
    }
}