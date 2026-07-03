using Forrajeria.Domain.Enums;
using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Entities
{
    public class Venta
    {
        // Aggregate Root
        private readonly List<DetalleVenta> _detalles = new();
        public IReadOnlyCollection<DetalleVenta> Detalles => _detalles;
        public int Id { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaConfirmacion { get; private set; }
        public DateTime? FechaCancelacion { get; private set; }
        public decimal Descuento { get; private set; }
        public EstadoVenta Estado { get; private set; }
        public decimal Total => _detalles.Sum(x => x.Subtotal) - Descuento;
        public Venta()
        {
            Estado = EstadoVenta.Pendiente;
            FechaCreacion = DateTime.Now;
            Descuento = 0;
        }
        public void AgregarDetalle(PresentacionProducto presentacion, decimal cantidad)
        {
            ValidarVentaPendiente();

            var detalleExistente = _detalles
                .FirstOrDefault(d => d.PresentacionProductoId == presentacion.Id);

            if (detalleExistente != null)
            {
                detalleExistente.AumentarCantidad(cantidad);
                return;
            }

            var detalle = new DetalleVenta(presentacion, cantidad);
            _detalles.Add(detalle);
        }

        public void EliminarDetalle(int detalleId)
        {
            ValidarVentaPendiente();

            var detalle = _detalles.FirstOrDefault(d => d.Id == detalleId);

            if (detalle == null)
                throw new DetalleNoEncontradoException();

            _detalles.Remove(detalle);
        }

        public void Confirmar()
        {
            ValidarVentaPendiente();
            ValidarTieneDetalles();

            Estado = EstadoVenta.Confirmada;
            FechaConfirmacion = DateTime.Now;
        }
        public void Cancelar()
        {
            ValidarPuedeCancelar();

            Estado = EstadoVenta.Cancelada;
            FechaCancelacion = DateTime.Now;
        }
        public void AplicarDescuento(decimal descuento)
        {
            ValidarVentaPendiente();
            ValidarDescuento(descuento);

            Descuento = descuento;
        }

        // -------------------------
        // Validaciones del agregado
        // -------------------------

        private void ValidarVentaPendiente()
        {
            if (Estado != EstadoVenta.Pendiente)
                throw new VentaNoModificableException();
        }

        private void ValidarTieneDetalles()
        {
            if (!_detalles.Any())
                throw new DetalleVacioException();
        }

        private void ValidarDescuento(decimal descuento)
        {
            if (descuento < 0)
                throw new DescuentoNegativoException();
        }

        private void ValidarPuedeCancelar()
        {
            if (Estado == EstadoVenta.Cancelada)
                throw new VentaCanceladaException();
        }
    }
}