using Autofac;
using Infrastructure.Authorization;

namespace Infrastructure.Configuration.Authorization
{
    internal class AuthorizationModule : Module
    {
        private readonly JwtOptions _jwtOptions;

        internal AuthorizationModule(string issuer, string audience, string secretKey)
        {
            _jwtOptions = new(issuer, audience, secretKey);
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtProvider>()
                .WithParameter("jwtOptions", _jwtOptions);
        }
    }
}
