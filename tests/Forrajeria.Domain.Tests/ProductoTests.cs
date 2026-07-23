using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Tests
{
    public class ProductoTests
    {

        [Fact]
        public void CrearProducto_CuandoElNombreEsVacio_DeberiaLanzarProductoNombreVacioException()
        {
            // Arrange
            string nombre = "";
            // Act & Assert
            Assert.Throws<ProductoNombreVacioException>(() =>
                new Producto(nombre, EntidadTestHelper.CrearCategoria()));
        }

        [Fact]
        public void CrearProducto_CuandoElNombreEsSoloEspacios_DeberiaLanzarProductoNombreVacioException()
        {
            // Act & Assert
            Assert.Throws<ProductoNombreVacioException>(() =>
                new Producto("   ", EntidadTestHelper.CrearCategoria()));
        }

        [Fact]
        public void CrearProducto_CuandoLaCategoriaEsNull_DeberiaLanzarCategoriaVaciaException()
        {
            // Act & Assert
            Assert.Throws<CategoriaVaciaException>(() =>
                new Producto("Balanceado", null!));
        }

        [Fact]
        public void CrearProducto_CuandoElNombreEsValido_DeberiaGuardarElNombre()
        {
            // Act
            Producto producto = EntidadTestHelper.CrearProducto("Balanceado");

            // Assert
            Assert.Equal("Balanceado", producto.Nombre);
        }

        [Fact]
        public void CrearProducto_DeberiaCrearseActivoPorDefecto()
        {
            // Arrange
            Producto producto = EntidadTestHelper.CrearProducto("Balanceado");
            // Assert
            Assert.True(producto.Activo);
        }

        [Fact]
        public void DesactivarProducto_DeberiaCambiarActivoAFalso()
        {
            // Arrange
            Producto producto = EntidadTestHelper.CrearProducto("Balanceado");
            // Act
            producto.Desactivar();
            // Assert
            Assert.False(producto.Activo);
        }

        [Fact]
        public void ActivarProducto_CuandoEstaInactivo_DeberiaCambiarActivoAVerdadero()
        {
            // Arrange
            Producto producto = EntidadTestHelper.CrearProducto("Balanceado");
            producto.Desactivar();
            // Act
            producto.Activar();
            // Assert
            Assert.True(producto.Activo);
        }

        [Fact]
        public void ModificarNombre_CuandoNombreEsValido_DeberiaActualizarNombre()
        {
            // Arrange
            Producto producto = EntidadTestHelper.CrearProducto("Balanceado");
            string nuevoNombre = "Balanceado Adulto";
            // Act
            producto.ModificarNombre(nuevoNombre);
            // Assert
            Assert.Equal(nuevoNombre, producto.Nombre);
        }

        [Fact]
        public void ModificarNombre_CuandoNombreEsVacio_DeberiaLanzarProductoNombreVacioException()
        {
            // Arrange
            Producto producto = EntidadTestHelper.CrearProducto("Balanceado");
            // Act & Assert
            Assert.Throws<ProductoNombreVacioException>(() =>
                producto.ModificarNombre(""));
        }

        [Fact]
        public void ValidarQueEsteActivo_CuandoElProductoEstaActivo_NoDeberiaLanzarExcepcion()
        {
            // Arrange
            Producto producto = EntidadTestHelper.CrearProducto("Balanceado");

            // Act & Assert
            Exception? excepcion = Record.Exception(() => producto.ValidarQueEsteActivo());
            Assert.Null(excepcion);
        }

        [Fact]
        public void ValidarQueEsteActivo_CuandoElProductoEstaInactivo_DeberiaLanzarProductoInactivoException()
        {
            // Arrange
            Producto producto = EntidadTestHelper.CrearProducto("Balanceado");
            producto.Desactivar();

            // Act & Assert
            Assert.Throws<ProductoInactivoException>(() =>
                producto.ValidarQueEsteActivo());
        }

    }
}