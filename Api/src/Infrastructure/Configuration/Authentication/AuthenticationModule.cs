using Application.Contracts;
using Application.Users;
using Autofac;
using Domain.Users;
using Infrastructure.Authentication;

namespace Infrastructure.Configuration.Authentication
{
    internal class AuthenticationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserContext>()
                .As<IUserContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();
        }
    }
}
