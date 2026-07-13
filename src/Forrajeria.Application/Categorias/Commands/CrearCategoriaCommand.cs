namespace Forrajeria.Application.Categorias.Commands
{
    public class CrearCategoriaCommand
    {
        public string Nombre { get; set; }
        public CrearCategoriaCommand(string nombre)
        {
            Nombre = nombre;
        }
    }
}
