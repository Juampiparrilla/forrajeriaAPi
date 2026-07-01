using Forrajeria.Domain.Entities;
using Forrajeria.Domain.Exceptions;

namespace Forrajeria.Domain.Tests
{
    public class ProductoTests
    {
        [Fact]
        public void ModificarPrecioVenta_CuandoElPrecioEsNegativo_DeberiaLanzarPrecioInvalidoException()
        {
            //Arrange
            Producto producto = new Producto("Producto1", 10.0m, 5m, 10);
            //Act Assert 
            Assert.Throws<PrecioInvalidoException>(() => producto.ModificarPrecioVenta(-15m));
        }      

        [Fact]
        public void VerificarProductoEnEstadoInactivo()
        {
            //Arrange
            Producto producto = new Producto("Producto2", 10.0m, 5m, 10);
            //Act   
            producto.Desactivar();           
            //Assert
            Assert.False(producto.Activo);
        }


    }
}