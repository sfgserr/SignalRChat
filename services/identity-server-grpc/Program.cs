using IdentityServer.Grpc.Data;
using IdentityServer.Grpc.Data.Repositories;
using IdentityServer.Grpc.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IdentityServer.Grpc
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
            builder.Services.AddRazorPages();
            builder.Services.AddGrpc();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.MapGrpcService<UserService>();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}