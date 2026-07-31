namespace Forrajeria.API.Authorization
{
    public static class Policies
    {
        public const string PuedeGestionarCategorias = nameof(PuedeGestionarCategorias);
        public const string PuedeVerCategorias = nameof(PuedeVerCategorias);

        public const string PuedeGestionarProductos = nameof(PuedeGestionarProductos);
        public const string PuedeVerProductos = nameof(PuedeVerProductos);

        public const string PuedeGestionarPresentaciones = nameof(PuedeGestionarPresentaciones);
        public const string PuedeVerPresentaciones = nameof(PuedeVerPresentaciones);

        public const string PuedeGestionarVentas = nameof(PuedeGestionarVentas);

        public const string PuedeGestionarUsuarios = nameof(PuedeGestionarUsuarios);
    }
}
