using Application.Contracts;
using Application.Cqrs.Commands;
using Application.Cqrs.Queries;
using Autofac;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.InternalCommands;
using Infrastructure.Processing;

namespace Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : Module
    {
        private readonly ISender _sender;

        internal ProcessingModule(ISender sender)
        {
            _sender = sender;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c) => _sender)
                .As<ISender>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandsScheduler>()
                .As<ICommandsScheduler>()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());

            builder.RegisterAssemblyTypes(Assemblies.Application, ThisAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerDependency()
                .FindConstructorsWith(new AllConstructorFinder());

            builder.RegisterAssemblyTypes(Assemblies.Application, ThisAssembly)
                .AsClosedTypesOf(typeof(ICommandHandlerWithResult<,>))
                .InstancePerDependency()
                .FindConstructorsWith(new AllConstructorFinder());

            builder.RegisterAssemblyTypes(Assemblies.Application, ThisAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerDependency()
                .FindConstructorsWith(new AllConstructorFinder());

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerDecorator<>),
                typeof(ICommandHandler<>));

            builder.RegisterGenericDecorator(
                typeof(ValidationCommandHandlerDecorator<>),
                typeof(ICommandHandler<>));

            builder.RegisterGenericDecorator(
                typeof(LoggingCommandHandlerDecorator<>),
                typeof(ICommandHandler<>));

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
                typeof(ICommandHandlerWithResult<,>));

            builder.RegisterGenericDecorator(
                typeof(ValidationCommandHandlerWithResultDecorator<,>),
                typeof(ICommandHandlerWithResult<,>));

            builder.RegisterGenericDecorator(
                typeof(LoggingCommandHandlerWithResultDecorator<,>),
                typeof(ICommandHandlerWithResult<,>));
        }
    }
}
