using Autofac;
using Infrastructure.Data;
using Infrastructure.Outbox;

namespace Infrastructure.Configuration.Outbox
{
    internal class OutboxModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new OutboxAccessor(c.Resolve<ApplicationContext>()))
            .As<IOutbox>()
            .InstancePerLifetimeScope();
        }
    }
}
