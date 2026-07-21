namespace Forrajeria.Application.Categorias.Commands.EditCategoria
{
    public class EditarCategoriaRequest
    {
        public string Nombre { get; }
        public EditarCategoriaRequest(string nombre)
        {
            Nombre = nombre;
        }
    }
}
