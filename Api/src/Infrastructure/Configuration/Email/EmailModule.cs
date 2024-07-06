using Application.Contracts;
using Autofac;
using Infrastructure.Email;

namespace Infrastructure.Configuration.Email
{
    internal class EmailModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailService>()
                .As<IEmailService>()
                .InstancePerLifetimeScope();
        }
    }
}
