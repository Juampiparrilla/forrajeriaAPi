using Forrajeria.Domain.Enums;
using Forrajeria.Domain.Exceptions.BusinessRules;

namespace Forrajeria.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public String Nombre { get; private set; }
        public String Email { get; private set; }
        public String PasswordHash { get; private set; }
        public Roles Rol { get; private set; }
        public bool Activo { get; private set; }

        public Usuario(String nombre, String email, String passwordHash, Roles rol)
        {
            Nombre = nombre;
            Email = email;
            PasswordHash = passwordHash;
            Rol = rol;
            Activo = true;
        }
        public void CambiarNombre(String nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new NombreUsuarioException();
            }
            Nombre = nombre;
        }

        public void CambiarEmail(String email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new EmailUsuarioException();
            }
            Email = email;
        }

        public void CambiarPasswordHash(String passwordHash)
        {
            if (string.IsNullOrEmpty(passwordHash))
            {
                throw new PasswordUsuarioException();
            }
            PasswordHash = passwordHash;
        }

        public void CambiarRol(Roles rol)
        {
            if (rol < 0)
            {
                throw new CambiarRolException();
            }
            Rol = rol;
        }
        public void Activar()
        {
            Activo = true;
        }
        public void Desactivar()
        {
            Activo = false;
        }
    }
}