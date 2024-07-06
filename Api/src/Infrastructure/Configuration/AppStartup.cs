using Application.Contracts;
using Autofac;
using Infrastructure.Configuration.Authentication;
using Infrastructure.Configuration.Data;
using Infrastructure.Configuration.DomainEventsDispatching;
using Infrastructure.Configuration.Email;
using Infrastructure.Configuration.Logging;
using Infrastructure.Configuration.Mediation;
using Infrastructure.Configuration.Outbox;
using Infrastructure.Configuration.Processing;
using Infrastructure.Configuration.Quartz;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;
using Serilog;

namespace Infrastructure.Configuration
{
    public class AppStartup
    {
        private static IContainer _container;

        public static void Initialize(string connectionString, ILogger logger, IUserService userService)
        {
            QuartzStartup.Initialize();

            ConfigureCompositionRoot(connectionString, logger.ForContext("Context", "App"), userService);
        }

        private static void ConfigureCompositionRoot(string connectionString, ILogger logger, IUserService userService)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new AuthenticationModule(userService));
            containerBuilder.RegisterModule(new DataAccessModule(connectionString));

            var mappings = new Dictionary<string, Type>
            {
                { "GroupCreatedDomainNotification", typeof(GroupCreatedDomainNotification) },
                { "MessageCreatedDomainNotification", typeof(MessageCreatedDomainNotification) },
                { "NewUserAddedToGroupDomainNotification", typeof(NewUserAddedToGroupDomainNotification) },
                { "UserCreatedDomainNotification", typeof(UserCreatedDomainNotification) }
            };
            containerBuilder.RegisterModule(new DomainEventsDispatchingModule(mappings));

            containerBuilder.RegisterModule(new LoggingModule(logger));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new OutboxModule());
            containerBuilder.RegisterModule(new EmailModule());

            _container = containerBuilder.Build();
            AppCompositionRoot.SetContainer(_container);
        }
    }
}
