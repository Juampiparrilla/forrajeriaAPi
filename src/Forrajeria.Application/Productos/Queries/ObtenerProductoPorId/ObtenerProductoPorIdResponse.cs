namespace Forrajeria.Application.Productos.Queries.ObtenerProductoPorId
{
    public record ObtenerProductoPorIdResponse(int Id, string Nombre, bool Activo, int CategoriaId, string CategoriaNombre);
}

