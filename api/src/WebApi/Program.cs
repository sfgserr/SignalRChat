
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication("Bearer")
                            .AddIdentityServerAuthentication("Bearer", options =>
                            {
                                options.Authority = "https://localhost:8084";
                                options.ApiName = "MessageApi";
                            });

            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("_allowsAny",
                    builder =>
                    {
                        // Not a permanent solution, but just trying to isolate the problem
                        builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });

            builder.Services.AddDataProtection()
                        .SetApplicationName("webapi")
                        .PersistKeysToFileSystem(new DirectoryInfo(@"./"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {   
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();
            app.UseForwardedHeaders();
            app.UseCors("_allowsAny");
            app.UseHttpsRedirection();

            app.Run();
        }
    }
}