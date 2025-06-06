using ManagementServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[$"Jwt:Key"] ?? "DefaultPolyTestManagementServerKeyDefaultPolyTestManagementServerKeyDefaultPolyTestManagementServerKeyDefaultPolyTestManagementServerKey"))
                };
            });

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.Listen(IPAddress.Any, builder.Configuration.GetValue<int>("ManagementGrpcServer:Port", 50052), listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http2;
            });
        });

        builder.Services.AddAuthorization();
        builder.Services.AddGrpc();

        var app = builder.Build();

        //app.UseGrpcWeb();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapGrpcService<ManagementServer.Services.AdminServiceImpl>();
        app.MapGet("/", () => "PolyTest Management Server");

        //app.UseEndpoints(endpoints =>
        //{
        //    endpoints.MapGrpcService<Services.AdminServiceImpl>();
        //    endpoints.MapGrpcService<Services.ExamServiceImpl>();
        //});

        app.Run();
    }
}