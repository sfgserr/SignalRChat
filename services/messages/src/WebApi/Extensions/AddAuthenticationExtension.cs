using Application.Services;
using Infrastructure.Authentication;

namespace WebApi.Extensions
{
    public static class AddAuthenticationExtension
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            services.AddScoped<IUserService, UserService>();
            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication("Bearer", options =>
                    {
                        options.Authority = configuration["Authentication:AuthorityUrl"];
                        options.ApiName = configuration["Authentication:ApiName"];
                        options.RequireHttpsMetadata = false;
                        options.JwtBackChannelHandler = handler;
                    });

            return services;
        }
    }
}
