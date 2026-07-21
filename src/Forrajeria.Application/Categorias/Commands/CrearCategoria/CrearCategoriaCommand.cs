namespace Forrajeria.Application.Categorias.Commands
{
    public class CrearCategoriaCommand
    {
        public string Nombre { get;}
        public CrearCategoriaCommand(string nombre)
        {
            Nombre = nombre;
        }
    }
}
