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
                new Producto(nombre));
        }

        [Fact]
        public void CrearProducto_DeberiaCrearseActivoPorDefecto()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");
            // Assert
            Assert.True(producto.Activo);
        }

        [Fact]
        public void DesactivarProducto_DeberiaCambiarActivoAFalso()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");
            // Act
            producto.Desactivar();
            // Assert
            Assert.False(producto.Activo);
        }

        [Fact]
        public void ActivarProducto_CuandoEstaInactivo_DeberiaCambiarActivoAVerdadero()
        {
            // Arrange
            Producto producto = new Producto("Balanceado");
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
            Producto producto = new Producto("Balanceado");
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
            Producto producto = new Producto("Balanceado");
            // Act & Assert
            Assert.Throws<ProductoNombreVacioException>(() =>
                producto.ModificarNombre(""));
        }

    }
}