using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Tests
{
    public class CategoriaTests
    {
        [Fact]
        public void CrearCategoria_CuandoElNombreEsVacio_DeberiaLanzarNombreCategoriaException()
        {
            //Arrange
            string nombreCategoria = "";
            //Act Assert 
            Assert.Throws<NombreCategoriaException>(() => new Categoria(nombreCategoria));
        }

        [Fact]
        public void CrearCategoria_DeberiaCrearseActivaPorDefecto()
        {
            //Arrange
            string nombreCategoria = "Alimentos";
            //Act
            Categoria categoria = new Categoria(nombreCategoria);
            //Assert
            Assert.True(categoria.Activo);
        }

        [Fact]
        public void ModificarNombre_CuandoElNombreEsValido_DeberiaModificarElNombre()
        {
            //Arrange
            string nombreCategoria = "Alimentos";
            Categoria categoria = new Categoria(nombreCategoria);
            string nuevoNombre = "Bebidas";
            //Act
            categoria.ModificarNombre(nuevoNombre);
            //Assert
            Assert.Equal(nuevoNombre, categoria.Nombre);
        }

        [Fact]
        public void ModificarNombre_CuandoElNombreEsVacio_DeberiaLanzarNombreCategoriaException()
        {
            //Arrange
            string nombreCategoria = "Alimentos";
            Categoria categoria = new Categoria(nombreCategoria);
            string nuevoNombre = "";
            //Act Assert 
            Assert.Throws<NombreCategoriaException>(() => categoria.ModificarNombre(nuevoNombre));
        }
        [Fact]
        public void DesactivarCategoria_DeberiaCambiarActivoAFalse()
        {
            //Arrange
            string nombreCategoria = "Alimentos";
            Categoria categoria = new Categoria(nombreCategoria);
            //Act
            categoria.Desactivar();
            //Assert
            Assert.False(categoria.Activo);
        }
        [Fact]
        public void Activar_DeberiaCambiarActivoATrue()
        {
            //Arrange
            string nombreCategoria = "Alimentos";
            Categoria categoria = new Categoria(nombreCategoria);
            //Act
            categoria.Desactivar();
            //Assert
            Assert.False(categoria.Activo);
        }       
    }
}
