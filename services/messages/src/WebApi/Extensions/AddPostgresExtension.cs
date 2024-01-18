using Application.Services;
using Domain;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    public static class AddPostgresExtension
    {
        public static IServiceCollection AddPostgresExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatContext>(options =>
                                               options.UseNpgsql(configuration["PostgreSql:ConnectionString"]));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
