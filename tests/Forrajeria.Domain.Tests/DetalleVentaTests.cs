using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Enums;
using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Tests
{
    public class DetalleVentaTests
    {
        [Fact]
        public void CrearDetalleVenta_CuandoLaPresentacionEsNull_DeberiaLanzarPresentacionProductoInvalidoException()
        {
            // Arrange
            PresentacionProducto presentacion = null;

            // Act & Assert
            Assert.Throws<PresentacionProductoInvalidoException>(() =>
                new DetalleVenta(presentacion, 2));
        }

        [Fact]
        public void CrearDetalleVenta_CuandoLaCantidadEsCero_DeberiaLanzarCantidadInvalidaException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act & Assert
            Assert.Throws<CantidadInvalidaException>(() =>
                new DetalleVenta(presentacion, 0));
        }

        [Fact]
        public void CrearDetalleVenta_CuandoLaCantidadEsNegativa_DeberiaLanzarCantidadInvalidaException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act & Assert
            Assert.Throws<CantidadInvalidaException>(() =>
                new DetalleVenta(presentacion, -5));
        }

        [Fact]
        public void CrearDetalleVenta_DeberiaGuardarLaPresentacion()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            DetalleVenta detalle = new DetalleVenta(presentacion, 2);

            // Assert
            Assert.Equal(presentacion, detalle.PresentacionProducto);
        }

        [Fact]
        public void CrearDetalleVenta_DeberiaGuardarLaDescripcionDeLaPresentacion()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            DetalleVenta detalle = new DetalleVenta(presentacion, 2);

            // Assert
            Assert.Equal(presentacion.DescripcionPresentacion, detalle.DescripcionPresentacion);
        }

        [Fact]
        public void CrearDetalleVenta_DeberiaGuardarElPrecioUnitarioActual()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            DetalleVenta detalle = new DetalleVenta(presentacion, 2);

            // Assert
            Assert.Equal(presentacion.PrecioVenta, detalle.PrecioUnitario);
        }

        [Fact]
        public void CrearDetalleVenta_DeberiaGuardarLaCantidadAVender()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            DetalleVenta detalle = new DetalleVenta(presentacion, 3);

            // Assert
            Assert.Equal(3, detalle.CantidadAVender);
        }

        [Fact]
        public void CrearDetalleVenta_DeberiaCalcularCorrectamenteElSubtotal()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            DetalleVenta detalle = new DetalleVenta(presentacion, 3);

            // Assert
            Assert.Equal(195000, detalle.Subtotal);
        }

        [Fact]
        public void CrearDetalleVenta_DeberiaGuardarUnSnapshotDelPrecio()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            DetalleVenta detalle = new DetalleVenta(presentacion, 2);

            // Act
            presentacion.ModificarPrecioCompra(100000);

            // Assert
            Assert.NotEqual(presentacion.PrecioVenta, detalle.PrecioUnitario);
            Assert.Equal(65000, detalle.PrecioUnitario);
        }
    }
}