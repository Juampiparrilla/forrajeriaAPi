using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Enums;
using Forrajeria.Domain.Exceptions.BusinessRules;

namespace Forrajeria.Domain.Tests
{
    public class PresentacionProductoTests
    {
        [Fact]
        public void CrearPresentacionProducto_CuandoProductoEsNull_DeberiaLanzarProductoVacioException()
        {
            // Arrange
            Producto producto = null;

            // Act & Assert
            Assert.Throws<ProductoVacioException>(() =>
                new PresentacionProducto(
                    producto,
                    UnidadMedida.Bolsa,
                    25,
                    5000,
                    30));
        }

        [Fact]
        public void CrearPresentacionProducto_CuandoUnidadMedidaEsInvalida_DeberiaLanzarUnidadMedidaException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            // Act & Assert
            Assert.Throws<UnidadMedidaException>(() =>
                new PresentacionProducto(
                    producto,
                    (UnidadMedida)999,
                    25,
                    5000,
                    30));
        }

        [Fact]
        public void CrearPresentacionProducto_CuandoCantidadEsMenorOIgualACero_DeberiaLanzarCantidadInvalidaException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            // Act & Assert
            Assert.Throws<CantidadInvalidaException>(() =>
                new PresentacionProducto(
                    producto,
                    UnidadMedida.Bolsa,
                    0,
                    5000,
                    30));
        }

        [Fact]
        public void CrearPresentacionProducto_CuandoCantidadEsNegativa_DeberiaLanzarCantidadInvalidaException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            // Act & Assert
            Assert.Throws<CantidadInvalidaException>(() =>
                new PresentacionProducto(
                    producto,
                    UnidadMedida.Bolsa,
                    -1,
                    5000,
                    30));
        }

        [Fact]
        public void CrearPresentacionProducto_CuandoPrecioCompraEsNegativo_DeberiaLanzarPrecioInvalidoException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            // Act & Assert
            Assert.Throws<PrecioInvalidoException>(() =>
                new PresentacionProducto(
                    producto,
                    UnidadMedida.Bolsa,
                    25,
                    -1,
                    30));
        }

        [Fact]
        public void CrearPresentacionProducto_CuandoMargenEsNegativo_DeberiaLanzarMargenGananciaInvalidoException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            // Act & Assert
            Assert.Throws<MargenGananciaInvalidoException>(() =>
                new PresentacionProducto(
                    producto,
                    UnidadMedida.Bolsa,
                    25,
                    5000,
                    -10));
        }

        [Fact]
        public void CrearPresentacionProducto_DeberiaGuardarLaUnidadMedida()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            // Act
            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                5000,
                30);

            // Assert
            Assert.Equal(UnidadMedida.Bolsa, presentacion.UnidadMedida);
        }

        [Fact]
        public void CrearPresentacionProducto_DeberiaCalcularCorrectamenteElPrecioVenta()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            // Act
            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Assert
            Assert.Equal(65000, presentacion.PrecioVenta);
        }

        [Fact]
        public void CrearPresentacionProducto_DeberiaGenerarLaDescripcionPresentacion()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            // Act
            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Assert
            Assert.Equal("Balanceado - 25 Bolsa", presentacion.DescripcionPresentacion);
        }

        [Fact]
        public void ModificarPrecioCompra_DeberiaActualizarElPrecioCompra()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            presentacion.ModificarPrecioCompra(60000);

            // Assert
            Assert.Equal(60000, presentacion.PrecioCompra);
        }

        [Fact]
        public void ModificarPrecioCompra_DeberiaRecalcularElPrecioVenta()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            presentacion.ModificarPrecioCompra(60000);

            // Assert
            Assert.Equal(78000, presentacion.PrecioVenta);
        }

        [Fact]
        public void ModificarPrecioCompra_CuandoPrecioEsNegativo_DeberiaLanzarPrecioInvalidoException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act & Assert
            Assert.Throws<PrecioInvalidoException>(() =>
                presentacion.ModificarPrecioCompra(-100));
        }

        [Fact]
        public void ModificarMargenGanancia_DeberiaActualizarElMargen()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            presentacion.ModificarMargenGanancia(50);

            // Assert
            Assert.Equal(50, presentacion.MargenGanancia);
        }

        [Fact]
        public void ModificarMargenGanancia_DeberiaRecalcularElPrecioVenta()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act
            presentacion.ModificarMargenGanancia(50);

            // Assert
            Assert.Equal(75000, presentacion.PrecioVenta);
        }

        [Fact]
        public void ModificarMargenGanancia_CuandoMargenEsNegativo_DeberiaLanzarMargenGananciaInvalidoException()
        {
            // Arrange
            Producto producto = new Producto("Balanceado", EntidadTestHelper.CrearCategoria());

            PresentacionProducto presentacion = new PresentacionProducto(
                producto,
                UnidadMedida.Bolsa,
                25,
                50000,
                30);

            // Act & Assert
            Assert.Throws<MargenGananciaInvalidoException>(() =>
                presentacion.ModificarMargenGanancia(-10));
        }
    }
}