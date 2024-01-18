using Microsoft.AspNetCore.DataProtection;

namespace WebApi.Extensions
{
    public static class AddCustomDataProtectionExtension
    {
        public static IServiceCollection AddCustomDataProtection(this IServiceCollection services)
        {
            services.AddDataProtection()
                    .SetApplicationName("webapi")
                    .PersistKeysToFileSystem(new DirectoryInfo(@"./"));

            return services;
        }
    }
}
