using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Enums;
using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Tests
{
    public class VentaTests
    {
        private static PresentacionProducto CrearPresentacion(int id, string nombre = "Balanceado", decimal precioCompra = 50000, decimal margen = 30)
        {
            var presentacion = new PresentacionProducto(
                new Producto(nombre),
                UnidadMedida.Bolsa,
                25,
                precioCompra,
                margen);

            EntidadTestHelper.AsignarId(presentacion, id);
            return presentacion;
        }

        [Fact]
        public void CrearVenta_DeberiaInicializarseEnEstadoPendiente()
        {
            // Act
            Venta venta = new Venta();

            // Assert
            Assert.Equal(EstadoVenta.Pendiente, venta.Estado);
            Assert.Equal(0, venta.Descuento);
            Assert.Empty(venta.Detalles);
        }

        [Fact]
        public void AgregarDetalle_CuandoLaVentaEstaPendiente_DeberiaAgregarUnDetalle()
        {
            // Arrange
            Venta venta = new Venta();
            PresentacionProducto presentacion = CrearPresentacion(1);

            // Act
            venta.AgregarDetalle(presentacion, 2);

            // Assert
            Assert.Single(venta.Detalles);
            Assert.Equal(2, venta.Detalles.First().CantidadAVender);
            Assert.Equal(130000, venta.Total);
        }

        [Fact]
        public void AgregarDetalle_CuandoLaPresentacionYaExiste_DeberiaAumentarLaCantidad()
        {
            // Arrange
            Venta venta = new Venta();
            PresentacionProducto presentacion = CrearPresentacion(1);

            venta.AgregarDetalle(presentacion, 2);

            // Act
            venta.AgregarDetalle(presentacion, 3);

            // Assert
            Assert.Single(venta.Detalles);
            Assert.Equal(5, venta.Detalles.First().CantidadAVender);
            Assert.Equal(325000, venta.Total);
        }

        [Fact]
        public void AgregarDetalle_CuandoLaCantidadEsInvalida_DeberiaLanzarCantidadInvalidaException()
        {
            // Arrange
            Venta venta = new Venta();
            PresentacionProducto presentacion = CrearPresentacion(1);

            // Act & Assert
            Assert.Throws<CantidadInvalidaException>(() =>
                venta.AgregarDetalle(presentacion, 0));
        }

        [Fact]
        public void AgregarDetalle_CuandoLaVentaNoEstaPendiente_DeberiaLanzarVentaNoModificableException()
        {
            // Arrange
            Venta venta = new Venta();
            PresentacionProducto presentacion = CrearPresentacion(1);
            venta.AgregarDetalle(presentacion, 1);
            venta.Confirmar();

            // Act & Assert
            Assert.Throws<VentaNoModificableException>(() =>
                venta.AgregarDetalle(presentacion, 1));
        }

        [Fact]
        public void EliminarDetalle_CuandoElDetalleExiste_DeberiaQuitarloDeLaVenta()
        {
            // Arrange
            Venta venta = new Venta();
            PresentacionProducto presentacion = CrearPresentacion(1);
            venta.AgregarDetalle(presentacion, 2);

            DetalleVenta detalle = venta.Detalles.First();
            EntidadTestHelper.AsignarId(detalle, 99);

            // Act
            venta.EliminarDetalle(99);

            // Assert
            Assert.Empty(venta.Detalles);
            Assert.Equal(0, venta.Total);
        }

        [Fact]
        public void EliminarDetalle_CuandoElDetalleNoExiste_DeberiaLanzarDetalleNoEncontradoException()
        {
            // Arrange
            Venta venta = new Venta();

            // Act & Assert
            Assert.Throws<DetalleNoEncontradoException>(() =>
                venta.EliminarDetalle(999));
        }

        [Fact]
        public void EliminarDetalle_CuandoLaVentaNoEstaPendiente_DeberiaLanzarVentaNoModificableException()
        {
            // Arrange
            Venta venta = new Venta();
            PresentacionProducto presentacion = CrearPresentacion(1);
            venta.AgregarDetalle(presentacion, 1);

            DetalleVenta detalle = venta.Detalles.First();
            EntidadTestHelper.AsignarId(detalle, 1);
            venta.Confirmar();

            // Act & Assert
            Assert.Throws<VentaNoModificableException>(() =>
                venta.EliminarDetalle(1));
        }

        [Fact]
        public void Confirmar_CuandoLaVentaTieneDetalles_DeberiaConfirmarLaVenta()
        {
            // Arrange
            Venta venta = new Venta();
            venta.AgregarDetalle(CrearPresentacion(1), 2);

            // Act
            venta.Confirmar();

            // Assert
            Assert.Equal(EstadoVenta.Confirmada, venta.Estado);
            Assert.NotNull(venta.FechaConfirmacion);
        }

        [Fact]
        public void Confirmar_CuandoLaVentaNoTieneDetalles_DeberiaLanzarDetalleVacioException()
        {
            // Arrange
            Venta venta = new Venta();

            // Act & Assert
            Assert.Throws<DetalleVacioException>(() =>
                venta.Confirmar());
        }

        [Fact]
        public void Confirmar_CuandoLaVentaYaEstaConfirmada_DeberiaLanzarVentaNoModificableException()
        {
            // Arrange
            Venta venta = new Venta();
            venta.AgregarDetalle(CrearPresentacion(1), 1);
            venta.Confirmar();

            // Act & Assert
            Assert.Throws<VentaNoModificableException>(() =>
                venta.Confirmar());
        }

        [Fact]
        public void Cancelar_CuandoLaVentaEstaPendiente_DeberiaCancelarLaVenta()
        {
            // Arrange
            Venta venta = new Venta();
            venta.AgregarDetalle(CrearPresentacion(1), 1);

            // Act
            venta.Cancelar();

            // Assert
            Assert.Equal(EstadoVenta.Cancelada, venta.Estado);
            Assert.NotNull(venta.FechaCancelacion);
        }

        [Fact]
        public void Cancelar_CuandoLaVentaYaEstaCancelada_DeberiaLanzarVentaCanceladaException()
        {
            // Arrange
            Venta venta = new Venta();
            venta.AgregarDetalle(CrearPresentacion(1), 1);
            venta.Cancelar();

            // Act & Assert
            Assert.Throws<VentaCanceladaException>(() =>
                venta.Cancelar());
        }

        [Fact]
        public void AplicarDescuento_CuandoElDescuentoEsValido_DeberiaAplicarloAlTotal()
        {
            // Arrange
            Venta venta = new Venta();
            venta.AgregarDetalle(CrearPresentacion(1), 2);

            // Act
            venta.AplicarDescuento(10000);

            // Assert
            Assert.Equal(10000, venta.Descuento);
            Assert.Equal(120000, venta.Total);
        }

        [Fact]
        public void AplicarDescuento_CuandoElDescuentoEsNegativo_DeberiaLanzarDescuentoNegativoException()
        {
            // Arrange
            Venta venta = new Venta();

            // Act & Assert
            Assert.Throws<DescuentoNegativoException>(() =>
                venta.AplicarDescuento(-1));
        }

        [Fact]
        public void AplicarDescuento_CuandoLaVentaNoEstaPendiente_DeberiaLanzarVentaNoModificableException()
        {
            // Arrange
            Venta venta = new Venta();
            venta.AgregarDetalle(CrearPresentacion(1), 1);
            venta.Confirmar();

            // Act & Assert
            Assert.Throws<VentaNoModificableException>(() =>
                venta.AplicarDescuento(1000));
        }
    }
}
