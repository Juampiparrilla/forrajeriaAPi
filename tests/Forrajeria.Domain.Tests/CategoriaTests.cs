using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Tests
{
    public class CategoriaTests
    {
        [Fact]
        public void CrearCategoria_CuandoElNombreEsVacio_DeberiaLanzarNombreCategoriaException()
        {
            // Arrange
            string nombreCategoria = "";
            // Act & Assert
            Assert.Throws<NombreCategoriaException>(() =>
                new Categoria(nombreCategoria));
        }

        [Fact]
        public void CrearCategoria_DeberiaCrearseActivaPorDefecto()
        {
            // Arrange
            string nombreCategoria = "Alimentos";
            // Act
            Categoria categoria = new Categoria(nombreCategoria);
            // Assert
            Assert.True(categoria.Activo);
        }

        [Fact]
        public void ModificarNombre_CuandoElNombreEsValido_DeberiaModificarElNombre()
        {
            // Arrange
            Categoria categoria = new Categoria("Alimentos");
            string nuevoNombre = "Bebidas";
            // Act
            categoria.ModificarNombre(nuevoNombre);
            // Assert
            Assert.Equal(nuevoNombre, categoria.Nombre);
        }

        [Fact]
        public void ModificarNombre_CuandoElNombreEsVacio_DeberiaLanzarNombreCategoriaException()
        {
            // Arrange
            Categoria categoria = new Categoria("Alimentos");
            string nuevoNombre = "";
            // Act & Assert
            Assert.Throws<NombreCategoriaException>(() =>
                categoria.ModificarNombre(nuevoNombre));
        }

        [Fact]
        public void DesactivarCategoria_DeberiaCambiarActivoAFalso()
        {
            // Arrange
            Categoria categoria = new Categoria("Alimentos");
            // Act
            categoria.Desactivar();
            // Assert
            Assert.False(categoria.Activo);
        }

        [Fact]
        public void ActivarCategoria_CuandoEstaInactiva_DeberiaCambiarActivoAVerdadero()
        {
            // Arrange
            Categoria categoria = new Categoria("Alimentos");
            categoria.Desactivar();
            // Act
            categoria.Activar();

            // Assert
            Assert.True(categoria.Activo);
        }
    }
}