using User.Grpc.Protos;
using Search.API.Services;
using Microsoft.IdentityModel.Logging;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;
using System.Security.Cryptography.X509Certificates;

namespace Search.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IdentityModelEventSource.ShowPII = true;
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
                Proxy = new WebProxy("http://chatauth.local")
            };
            builder.Services.AddAuthorization();
            builder.Services.AddGrpcClient<UserProtoService.UserProtoServiceClient>(o =>
            {
                o.Address = new Uri(builder.Configuration["GrpcSettings:Url"]);
            })
            .ConfigurePrimaryHttpMessageHandler(() => handler);

            builder.Services.AddScoped<UserService>();
            builder.Services.AddControllers();
            builder.Services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication("Bearer", options =>
            {
                options.Authority = builder.Configuration["Authentication:AuthorityUrl"];
                options.ApiName = builder.Configuration["Authentication:ApiName"];
                options.RequireHttpsMetadata = false;
                options.JwtBackChannelHandler = handler;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Run();
        }
    }
}