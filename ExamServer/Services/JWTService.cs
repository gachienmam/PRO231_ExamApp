using DocumentFormat.OpenXml.Spreadsheet;
using ExamServer.Database.DTO;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Services
{
    internal class JWTService
    {
        public IConfiguration Configuration;

        public JWTService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateJwtToken(NguoiDung user, ServerCallContext context)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.HoTen),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.VaiTro) // Add user role
            };

            var userContext = context.GetHttpContext().User;
            string role = userContext.IsInRole("Admin") == true || userContext.IsInRole("GiangVien") == true ? "Management" : "User";
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
