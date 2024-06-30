using Application.Users;
using Autofac;
using Domain.Users;

namespace Infrastructure.Configuration.Authentication
{
    internal class AuthenticationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserContext>()
                .As<IUserContext>()
                .InstancePerLifetimeScope();
        }
    }
}
