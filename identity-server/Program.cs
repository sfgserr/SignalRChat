using IdentityServer;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;

builder.Services.AddDbContext<ApplicationDbContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                   b => b.MigrationsAssembly(assembly)));

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddAuthentication();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
    options.EmitStaticAudienceClaim = true;
})
.AddInMemoryCaching()
.AddInMemoryApiScopes(Config.ApiScopes)
.AddInMemoryApiResources(Config.ApiResources)
.AddInMemoryClients(Config.Clients)
.AddInMemoryIdentityResources(Config.IdentityResources)
.AddAspNetIdentity<ApplicationUser>()
.AddDeveloperSigningCredential();

builder.Services.AddAuthorization();

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
            .SetApplicationName("identity-server")
            .PersistKeysToFileSystem(new DirectoryInfo(@"./"));

var app = builder.Build();

app.UseIdentityServer();
app.UseAuthentication();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
app.UseCors("_allowsAny");
app.UseHttpsRedirection();

await UsersSeed.Seed(app.Services);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
