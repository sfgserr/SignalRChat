using Microsoft.AspNetCore.HttpOverrides;
using System.Security.Cryptography.X509Certificates;

namespace WebApi.Extensions
{
    public static class AddProxyExtension
    {
        public static IServiceCollection AddProxy(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            return services;
        }
    }
}
