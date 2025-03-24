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
                new Claim(JwtRegisteredClaimNames.Sub, user.HoTen),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.VaiTro) // Add user role
            };
            string role = user.VaiTro.Equals("Admin") == true || user.VaiTro.Equals("GiangVien") == true ? "Management" : "User";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[$"Jwt{role}:Key"] ?? "DefaultPolyTestExamServerKey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: Configuration[$"Jwt{role}:Issuer"],
                audience: Configuration[$"Jwt{role}:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal? ValidateToken(string token, ServerCallContext context)
        {
            var userContext = context.GetHttpContext().User;
            string role = userContext.IsInRole("Admin") == true || userContext.IsInRole("GiangVien") == true ? "Management" : "User";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Configuration[$"Jwt{role}:Key"] ?? "DefaultPolyTestExamServerKey");

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration[$"Jwt{role}:Issuer"],
                    ValidAudience = Configuration[$"Jwt{role}:Audience"],
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
