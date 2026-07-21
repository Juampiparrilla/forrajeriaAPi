namespace Forrajeria.Application.Categorias.Commands.EditCategoria
{
    public class EditarCategoriaCommand
    {   public int Id { get; }
        public string Nombre { get; }
        public EditarCategoriaCommand(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
