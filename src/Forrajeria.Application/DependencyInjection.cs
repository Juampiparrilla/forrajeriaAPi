using Forrajeria.Application.Categorias.Commands.ActivarCategoria;
using Forrajeria.Application.Categorias.Commands.CrearCategoria;
using Forrajeria.Application.Categorias.Commands.DesactivarCategoria;
using Forrajeria.Application.Categorias.Commands.EditCategoria;
using Forrajeria.Application.Categorias.Queries.ListarCategorias;
using Forrajeria.Application.Categorias.Queries.ObtenerCategoriaPorId;
using Microsoft.Extensions.DependencyInjection;

namespace Forrajeria.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<CrearCategoriaHandler>();
        services.AddScoped<ListarCategoriasHandler>();
        services.AddScoped<ObtenerCategoriaPorIdHandler>();
        services.AddScoped<EditarCategoriaHandler>();
        services.AddScoped<DesactivarCategoriaHandler>();
        services.AddScoped<ActivarCategoriaHandler>();

        return services;
    }
}