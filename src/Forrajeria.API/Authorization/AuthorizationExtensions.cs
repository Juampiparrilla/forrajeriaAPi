namespace Forrajeria.API.Authorization
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddApiAuthorization(this IServiceCollection services)
        {

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.PuedeGestionarCategorias, policy => policy.RequireRole(RoleNames.Administrador));
                options.AddPolicy(Policies.PuedeVerCategorias, policy => policy.RequireRole(RoleNames.Administrador, RoleNames.Vendedor));

                options.AddPolicy(Policies.PuedeGestionarProductos, policy => policy.RequireRole(RoleNames.Administrador));
                options.AddPolicy(Policies.PuedeVerProductos, policy => policy.RequireRole(RoleNames.Administrador, RoleNames.Vendedor));

                options.AddPolicy(Policies.PuedeGestionarPresentaciones, policy => policy.RequireRole(RoleNames.Administrador));
                options.AddPolicy(Policies.PuedeVerPresentaciones, policy => policy.RequireRole(RoleNames.Administrador, RoleNames.Vendedor));

                options.AddPolicy(Policies.PuedeGestionarVentas, policy => policy.RequireRole(RoleNames.Administrador, RoleNames.Vendedor));

                options.AddPolicy(Policies.PuedeGestionarUsuarios, policy => policy.RequireRole(RoleNames.Administrador));
            });

            return services;
        }
    }
}
