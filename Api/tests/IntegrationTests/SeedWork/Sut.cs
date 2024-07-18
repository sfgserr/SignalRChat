using Application.Contracts;
using Autofac;
using Infrastructure;
using Infrastructure.Configuration;
using Infrastructure.Data;
using IntegrationTests.SeedWork.Probing;
using IntegrationTests.SeedWork.Testing;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IntegrationTests.SeedWork
{
    public class Sut
    {
        protected IAppModule AppModule { get; private set; }

        protected ILogger Logger { get; private set; }

        protected IUserService UserServiceMock { get; private set; }

        protected ISender SenderMock { get; private set; } 

        protected async Task<TestResult> Test(Func<Task> test)
        {
            BeforeTest();

            try
            {
                await test();
            }
            catch (AssertException ex)
            {
                return new TestResult(ex.Message);
            }
            finally
            {
                await AfterTest();
            }

            return new TestResult();
        }

        protected async Task AssertEventually(int timeout, IProbe test)
        {
            await new Poller(timeout).CheckAsync(test);
        }

        private void BeforeTest()
        {
            string connectionString = 
                Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User) 
                ?? "CONNECTION_STRING";

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

        private async Task AfterTest()
        {
            using var scope = AppCompositionRoot.BeginLifetimeScope();

            var context = scope.Resolve<ApplicationContext>();

            context.Database.ExecuteSqlRaw("DELETE FROM GroupUsers");
            context.Database.ExecuteSqlRaw("DELETE FROM Groups");

            await context.SaveChangesAsync();
        }
    }
}
