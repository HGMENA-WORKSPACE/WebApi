namespace WebApi.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="TokenService" />.
    /// </summary>
    public class TokenService
    {
        /// <summary>
        /// Defines the _configuration.
        /// </summary>
        private IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// The GenerarToken.
        /// </summary>
        /// <param name="user">The user<see cref="UserModel"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GenerarToken(UserModel user)
        {
            //Accedemos a la sección JwtSettings del archivo appsettings.json
            var jwtSettings = _configuration.GetSection("JwSettings");
            //Obtenemos la clave secreta guardada en JwtSettings:SecretKey
            string secretKey = jwtSettings.GetValue<string>("SecretKey");
            //Obtenemos el tiempo de vida en minutos del Jwt guardada en JwtSettings:MinutesToExpiration
            int minutes = jwtSettings.GetValue<int>("MinutesToExpiration");
            //Obtenemos el valor del emisor del token en JwtSettings:Issuer
            string issuer = jwtSettings.GetValue<string>("Issuer");
            //Obtenemos el valor de la audiencia a la que está destinado el Jwt en JwtSettings:Audience
            string audience = jwtSettings.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secretKey);

            //Creamos nuestra lista de Claims, en este caso para el Username,
            //el Email y el Perfil del Usuario.
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Mail));
            claims.Add(new Claim(ClaimTypes.Role, user.IdRolTask.ToString()));


            // Creamos el objeto JwtSecurityToken
            JwtSecurityToken jwtToken = new JwtSecurityToken(
              issuer: issuer,
              audience: audience,
              claims: claims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddMinutes(minutes),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            // Creamos una representación en cadena del Token JWT (Json Web Token)
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
