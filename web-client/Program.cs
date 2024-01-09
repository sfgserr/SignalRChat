using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthorization();

            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(
                OpenIdConnectDefaults.AuthenticationScheme,
                options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
                    options.MetadataAddress = builder.Configuration["InteractiveServiceSettings:MetadataAddress"];
                    options.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
                    options.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
                    options.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];
                    options.RequireHttpsMetadata = false;
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                }
            );

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
                        .SetApplicationName("webclient")
                        .PersistKeysToFileSystem(new DirectoryInfo(@"./"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapRazorPages();
            app.MapDefaultControllerRoute();
            app.UseHttpsRedirection();
            app.UseForwardedHeaders();
            app.UseCors("_allowsAny");
            app.Run();
        }
    }
}