using IdentityServer;
using IdentityServer.Data;
using IdentityServer.Models;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;

builder.Services.AddAuthorization();
builder.Services.AddDbContext<ApplicationDbContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                   b => b.MigrationsAssembly(assembly)));

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

var cert = new X509Certificate2("/https/localhost.pfx", "MyPass");

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
    options.EmitStaticAudienceClaim = true;
})
.AddSigningCredential(cert)
.AddInMemoryCaching()
.AddInMemoryApiScopes(Config.ApiScopes)
.AddInMemoryApiResources(Config.ApiResources)
.AddInMemoryClients(Config.Clients)
.AddInMemoryIdentityResources(Config.IdentityResources)
.AddAspNetIdentity<ApplicationUser>();

builder.Services.AddAuthorization();
builder.Services.AddGrpc();

builder.Services.AddDataProtection()
            .SetApplicationName("identity-server")
            .PersistKeysToFileSystem(new DirectoryInfo(@"./"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.UseHsts();

await UsersSeed.Seed(app.Services);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
