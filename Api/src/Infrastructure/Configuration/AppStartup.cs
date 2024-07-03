using Autofac;
using Infrastructure.Configuration.Authentication;
using Infrastructure.Configuration.Data;
using Infrastructure.Configuration.DomainEventsDispatching;
using Infrastructure.Configuration.Mediation;
using Infrastructure.Configuration.Outbox;
using Infrastructure.Configuration.Processing;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.Configuration
{
    public class AppStartup
    {
        private static IContainer _container;

        public static void Initialize(string connectionString)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new AuthenticationModule());
            containerBuilder.RegisterModule(new DataAccessModule(connectionString));

            var mappings = new Dictionary<string, Type>
            {
                { "GroupCreatedDomainNotification", typeof(GroupCreatedDomainNotification) },
                { "MessageCreatedDomainNotification", typeof(MessageCreatedDomainNotification) },
                { "NewUserAddedToGroupDomainNotification", typeof(NewUserAddedToGroupDomainNotification) },
                { "UserCreatedDomainNotification", typeof(UserCreatedDomainNotification) }
            };
            containerBuilder.RegisterModule(new DomainEventsDispatchingModule(mappings));

            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new OutboxModule());
            containerBuilder.RegisterModule(new ProcessingModule());

            _container = containerBuilder.Build();
        }
    }
}
