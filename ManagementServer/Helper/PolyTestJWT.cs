using Grpc.Core;
using Microsoft.IdentityModel.Tokens;
using ServerDatabaseLibrary.Database.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementServer.Helper
{
    internal class PolyTestJWT
    {
        public IConfiguration Configuration;

        public PolyTestJWT(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateJwtToken(string email, NguoiDung user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.VaiTro) // Add user role
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[$"Jwt:Key"] ?? "DefaultPolyTestManagementServerKey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: Configuration[$"Jwt:Issuer"],
                audience: Configuration[$"Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal? ValidateToken(string token, ServerCallContext context)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Configuration[$"Jwt:Key"] ?? "DefaultPolyTestManagementServerKey");

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration[$"Jwt:Issuer"],
                    ValidAudience = Configuration[$"Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out _);

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
