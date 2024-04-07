using Microsoft.IdentityModel.Logging;
using WebApi.Extensions;

namespace WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;

            services.AddUseCases()
                    .AddProxy()
                    .AddCustomCors()
                    .AddCustomDataProtection()
                    .AddAuthentication(_configuration)
                    .AddPostgresExtensions(_configuration);

            services.AddHttpContextAccessor();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions() { ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All})
               .UseCors("_allowsAny")
               .UseHttpsRedirection()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(e =>
               {
                   e.MapControllers();
               });
        }
    }
}
