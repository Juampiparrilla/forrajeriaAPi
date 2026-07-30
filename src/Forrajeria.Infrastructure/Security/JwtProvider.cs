using Forrajeria.Application.Interfaces;
using Forrajeria.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Forrajeria.Infrastructure.Security
{
    internal class JwtProvider : IJwtProvider
    {
        // Cambiar este acoplamiento por JwtOptions
        private readonly IConfiguration _config;
        public JwtProvider(IConfiguration config)
        {
            _config = config;
        }
        public string GenerarToken(Usuario usuario)
        {

            var key = _config["JWT:Key"];

            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("Falta la configuración JWT:Key.");
            }

            var issuer = _config["JWT:Issuer"];

            if (string.IsNullOrEmpty(issuer))
            {
                throw new InvalidOperationException("Falta la configuración JWT:Issuer.");
            }

            var audience = _config["JWT:Audience"];

            if (string.IsNullOrEmpty(audience))
            {
                throw new InvalidOperationException("Falta la configuración JWT:Audience.");
            }

            var duration = _config.GetValue<int>("JWT:DurationInMinutes");

            if (duration <= 0)
            {
                throw new InvalidOperationException("Falta la configuración JWT:DurationInMinutes.");
            }



            var claims = new List<Claim>() {
                         new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                         new Claim(ClaimTypes.Role, usuario.Rol.ToString()),
                         new Claim(ClaimTypes.Email, usuario.Email),
                         new Claim(ClaimTypes.Name, usuario.Nombre)
            };


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
           
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(duration),
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
