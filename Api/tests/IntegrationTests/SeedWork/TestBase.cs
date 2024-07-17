using Application.Contracts;
using Autofac;
using Infrastructure;
using Infrastructure.Configuration;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IntegrationTests.SeedWork
{
    public class TestBase
    {
        protected IAppModule AppModule { get; private set; }

        protected ILogger Logger { get; private set; }

        protected IUserService UserServiceMock { get; private set; }

        protected ISender SenderMock { get; private set; } 

        protected void BeforeTest()
        {
            string connectionString = 
                Environment.GetEnvironmentVariable("SqlServerSettings:ConnectionString") ?? "CONNECTION_STRING";

            Logger = new LoggerConfiguration()
                .Enrich.FromLogContext().WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            UserServiceMock = new UserServiceMock();

            SenderMock = new SenderMock();

            AppStartup.Initialize(connectionString, Logger, UserServiceMock, SenderMock);

            using var scope = AppCompositionRoot.BeginLifetimeScope();

            var context = scope.Resolve<ApplicationContext>();

            context.Database.Migrate();

            AppModule = new AppModule();
        }

        protected void AfterTest()
        {
            using var scope = AppCompositionRoot.BeginLifetimeScope();

            var context = scope.Resolve<ApplicationContext>();

            context.Database.EnsureDeleted();
        }
    }
}
