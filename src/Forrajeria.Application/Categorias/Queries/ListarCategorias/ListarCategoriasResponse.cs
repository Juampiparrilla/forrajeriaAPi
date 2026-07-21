namespace Forrajeria.Application.Categorias.Queries.ListarCategorias
{
    public class ListarCategoriasResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public ListarCategoriasResponse(int id, string nombre, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Activo = activo;
        }
    }
}
