using Application.Contracts;
using Autofac;
using Infrastructure;

namespace WebApi.Chat
{
    public class AppAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppModule>()
                .As<IAppModule>()
                .InstancePerLifetimeScope();
        }
    }
}
