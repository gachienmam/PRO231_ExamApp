using Grpc.Core;
using Microsoft.IdentityModel.Tokens;
using ServerDatabaseLibrary.Database.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExamServer.Helper
{
    internal class PolyTestJWT
    {
        public IConfiguration Configuration;

        public PolyTestJWT(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateJwtToken(ThiSinh user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.MaThiSinh),
                new Claim(JwtRegisteredClaimNames.Name, user.HoTen),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.PhoneNumber, user.SoDienThoai),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.NgaySinh.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("MaThiSinh", user.MaThiSinh)
                //new Claim(ClaimTypes.Role, user.VaiTro) // Add user role
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[$"Jwt:Key"] ?? "DefaultPolyTestExamServerKeyDefaultPolyTestExamServerKeyDefaultPolyTestExamServerKeyDefaultPolyTestExamServerKeyDefaultPolyTestExamServerKey"));
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
            var key = Encoding.UTF8.GetBytes(Configuration[$"Jwt:Key"] ?? "DefaultPolyTestExamServerKeyDefaultPolyTestExamServerKeyDefaultPolyTestExamServerKeyDefaultPolyTestExamServerKeyDefaultPolyTestExamServerKey");

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
