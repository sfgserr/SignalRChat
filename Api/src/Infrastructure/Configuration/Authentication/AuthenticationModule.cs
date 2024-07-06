using Application.Contracts;
using Application.Users;
using Autofac;
using Domain.Users;

namespace Infrastructure.Configuration.Authentication
{
    internal class AuthenticationModule : Module
    {
        private readonly IUserService _userService;

        internal AuthenticationModule(IUserService userService)
        {
            _userService = userService;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserContext>()
                .As<IUserContext>()
                .WithParameter("userService", _userService)
                .InstancePerLifetimeScope();
        }
    }
}
