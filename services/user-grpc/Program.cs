using User.Grpc.Data;
using User.Grpc.Data.Repositories;
using User.Grpc.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User.Grpc.Protos;

namespace User.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var assembly = typeof(Program).Assembly.GetName().Name;

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(o => 
                o.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                               b => b.MigrationsAssembly(assembly)));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddRazorPages();
            builder.Services.AddGrpc();
            var app = builder.Build();

            app.UseHsts();
            app.UseStaticFiles();
                
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<UserService>();
            });
            app.MapRazorPages();

            app.Run();
        }
    }
}