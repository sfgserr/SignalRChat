using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Hellang.Middleware.ProblemDetails;
using System.Text;
using Application.Exceptions;
using WebApi.Configuration.Validation;
using Domain.Exceptions;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
using ILogger = Serilog.ILogger;
using Serilog;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Configuration;
using Autofac;
using Application.Contracts;
using WebApi.Configuration.Authentication;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Infrastructure.Data.ValueConversion;
using WebApi.Chat;
using Microsoft.AspNetCore.Authentication;
using WebApi.Configuration.Authorization;
using WebApi.Configuration.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    public class Startup
    {
        private ILogger _logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ConfigureLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string issuer = Configuration["JwtSettings:Issuer"]!;
            string audience = Configuration["JwtSettings:Audience"]!;
            string secretKey = Configuration["JwtSettings:SecretKey"]!;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            services.AddSignalR();
            services.AddAuthorization();

            services.AddHttpContextAccessor();

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(Configuration["SqlServerSettings:ConnectionString"]);
                options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
            });

            services.AddProblemDetails(x =>
            {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationProblemDetails(ex));
            });

            services.AddScoped<ISender, Sender>();
            services.AddSingleton<JwtProvider>(x => new(new(issuer, audience, secretKey)));
            services.AddSingleton<IAuthorizationHandler, HasPermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, HasPermissionAuthorizationPolicyProvider>();
            services.AddScoped<IClaimsTransformation, CustomClaimsTransformation>();
            services.AddSingleton<IUserService, UserService>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AppAutofacModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var container = app.ApplicationServices.GetAutofacRoot();

            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            AppStartup.Initialize(
                Configuration["SqlServerSettings:ConnectionString"]!, 
                _logger, 
                container.Resolve<IUserService>(),
                container.Resolve<ISender>());

            var context = container.Resolve<ApplicationContext>();
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseProblemDetails();
            app.UseEndpoints(e => 
            {
                e.MapControllers();
                e.MapHub<ChatHub>("/chat");
            });
        }

        private void ConfigureLogger()
        {
            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
