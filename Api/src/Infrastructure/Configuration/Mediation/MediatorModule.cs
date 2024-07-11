using Application.Cqrs.Commands;
using Autofac;
using Autofac.Features.Variance;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Infrastructure.Configuration.Mediation
{
    internal class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterType<ServiceProviderWrapper>()
                .As<IServiceProvider>()
                .InstancePerDependency()
                .IfNotRegistered(typeof(IServiceProvider))
                .FindConstructorsWith(new AllConstructorFinder());

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var types = new[]
            {
                typeof(INotificationHandler<>),
                typeof(IValidator<>)
            };

            foreach (var type in types)
            {
                builder.RegisterAssemblyTypes(Assemblies.Application, ThisAssembly)
                    .AsClosedTypesOf(type)
                    .AsImplementedInterfaces()
                    .InstancePerDependency()
                    .FindConstructorsWith(new AllConstructorFinder());
            }
        }
    }
}
