using Forrajeria.Domain.Enums;

namespace Forrajeria.Domain.Entities
{
    public class Venta
    {
        public int Id { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaConfirmacion { get; private set; }
        public decimal Descuento { get; private set; }
        public List<DetalleVenta> DetalleVenta { get; private set; }
        //public EstadoVentaEnum Estado { get; private set; }
        public decimal Total { get; private set; }

        //public Venta(DateTime fechaCreacion, decimal descuento, List<DetalleVenta> detalleVenta )
        //{

        //}

        //AgregarProducto()

        //Confirmar()

        //Cancelar()

        //CalcularTotal()


    }
}
