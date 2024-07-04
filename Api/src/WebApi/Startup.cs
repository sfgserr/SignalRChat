﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.AspNetCore.Builder;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Configuration;

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

            services.AddAuthorization();

            services.AddHttpContextAccessor();

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddProblemDetails(x =>
            {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationProblemDetails(ex));
            });

            services.AddScoped<JwtProvider>(x => new(new(issuer, audience, secretKey)));
            services.AddScoped<IAuthorizationHandler, HasPermissionAuthorizationHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var container = app.ApplicationServices.GetAutofacRoot();

            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            AppStartup.Initialize(Configuration["SqlServerSettings:ConnectionString"]!, _logger);

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(e => e.MapControllers());
        }

        private void ConfigureLogger()
        {
            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
