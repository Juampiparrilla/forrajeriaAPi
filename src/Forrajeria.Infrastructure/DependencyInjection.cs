using Forrajeria.Application.Interfaces;
using Forrajeria.Infrastructure.Persistence;
using Forrajeria.Infrastructure.Persistence.Repositories;
using Forrajeria.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forrajeria.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ForrajeriaDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IPresentacionProductoRepository, PresentacionProductoRepository>();
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
