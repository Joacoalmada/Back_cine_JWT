using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Back.Data.Customs;
using System.Runtime.Intrinsics.Arm;
using Back.Data.Models;
using Back.Data.Models;

namespace Back.Data.Customs
{
    public class Utilidades
    {
        private readonly IConfiguration _config;

        public Utilidades(IConfiguration config) 
        {
            _config = config;
        }

        public string encriptarSHA256(string text)
        {
            using(SHA256 sha256Hash = SHA256.Create()) 
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                 StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                { 
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString(); 
            }
          
        }

        public string generarJWT(Usuario usuario) 
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Email,usuario.Email),
                new Claim(ClaimTypes.Name,usuario.Nombre),
                new Claim(ClaimTypes.Surname, usuario.Apellido)
            };


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);


            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);


        }


    }
}
