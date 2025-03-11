using ExamServer.Services;
using Grpc.AspNetCore;
using Grpc.Net.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Xml.Linq;
using System.Text;

/*
 * EOS - Exam Server
 * 3-6-2025
 * 
 * by monke
 */

namespace ExamServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddGrpc();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapGrpcService<Services.ExamServiceImpl>();

            app.Run();
        }

        #region Strings / Variables

        public static string serverAddr = "127.0.0.1";

        public static string directory_AppRoot = AppDomain.CurrentDomain.BaseDirectory;

        public static string directory_StudentData = directory_AppRoot + "\\studentdata";

        public static string directory_Database = directory_AppRoot + "\\database";

        public static string directory_Logs = directory_AppRoot + "\\logs";

        public static string? serverBroadcast { get; set; }

        public static bool IsHandlingCommands { get; set; } = false;

        #endregion
    }
}