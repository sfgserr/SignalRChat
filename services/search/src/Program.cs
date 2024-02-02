using User.Grpc.Protos;
using Microsoft.Extensions.DependencyInjection;
using Search.API.Services;

namespace Search.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddGrpcClient<UserProtoService.UserProtoServiceClient>(o =>
            {
                o.Address = new Uri(builder.Configuration["GrpcSettings:Url"]);
            })//Not for production
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                return handler;
            });

            builder.Services.AddScoped<UserService>();
            builder.Services.AddControllers();
            builder.Services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication("Bearer", options =>
                    {
                        options.Authority = builder.Configuration["Authentication:AuthorityUrl"];
                        options.ApiName = builder.Configuration["Authentication:ApiName"];
                        options.RequireHttpsMetadata = false;
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}