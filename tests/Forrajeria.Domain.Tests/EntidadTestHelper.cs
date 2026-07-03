using System.Reflection;

namespace Forrajeria.Domain.Tests
{
    internal static class EntidadTestHelper
    {
        public static void AsignarId(object entidad, int id)
        {
            PropertyInfo? propiedad = entidad.GetType().GetProperty("Id")
                ?? throw new InvalidOperationException($"La entidad {entidad.GetType().Name} no tiene propiedad Id.");

            propiedad.SetValue(entidad, id);
        }
    }
}
