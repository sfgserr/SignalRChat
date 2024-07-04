using Application.Contracts;
using Application.Cqrs.Commands;
using Application.Cqrs.Queries;
using Application.Groups.Commands.AddUser;
using Application.Groups.Commands.ChangeGroupName;
using Application.Groups.Commands.ChangeIconUri;
using Application.Groups.Commands.CreateGroup;
using Application.Groups.Commands.RemoveUser;
using Application.Groups.DomainEventHandlers;
using Application.Groups.Queries;
using Application.Groups.Queries.GetGroup;
using Application.Groups.Queries.GetUserGroups;
using Application.Groups.Queries.GetUserPermissions;
using Application.Messages.Commands.CreateMessage;
using Application.Messages.Commands.EditMessage;
using Application.Messages.Commands.ReadMessage;
using Application.Messages.DomainEventHandlers;
using Application.Messages.Queries.GetMessages;
using Application.Users.Commands.Authenticate;
using Application.Users.Commands.Register;
using Application.Users.DomainEventHandlers;
using Autofac;
using Domain.Groups;
using Domain.Groups.Events;
using Domain.Messages.Events;
using Domain.Users.Events;
using FluentValidation;
using Infrastructure.Processing;

namespace Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GroupCreatedDomainEventHandler>()
                .As<IDomainEventHandler<GroupCreatedDomainEvent>>()
                .InstancePerDependency();

            builder.RegisterType<NewUserAddedToGroupDomainEventHandler>()
                .As<IDomainEventHandler<NewUserAddedToGroupDomainEvent>>()
                .InstancePerDependency();

            builder.RegisterType<MessageCreatedDomainEventHandler>()
                .As<IDomainEventHandler<MessageCreatedDomainEvent>>()
                .InstancePerDependency();

            builder.RegisterType<UserCreatedDomainEventHandler>()
                .As<IDomainEventHandler<UserCreatedDomainEvent>>()
                .InstancePerDependency();

            builder.RegisterType<AddUserCommandHandler>()
                .As<ICommandHandler<AddUserCommand>>()
                .InstancePerDependency();

            builder.RegisterType<ChangeGroupNameCommandHandler>()
                .As<ICommandHandler<ChangeGroupNameCommand>>()
                .InstancePerDependency();

            builder.RegisterType<ChangeIconUriCommandHandler>()
                .As<ICommandHandler<ChangeIconUriCommand>>()
                .InstancePerDependency();

            builder.RegisterType<CreateGroupCommandHandler>()
                .As<ICommandHandler<CreateGroupCommand>>()
                .InstancePerDependency();

            builder.RegisterType<RemoveUserCommandHandler>()
                .As<ICommandHandler<RemoveUserCommand>>()
                .InstancePerDependency();

            builder.RegisterType<GetGroupQueryHandler>()
                .As<IQueryHandler<GetGroupQuery, GroupDto>>()
                .InstancePerDependency();

            builder.RegisterType<GetUserGroupsQueryHandler>()
                .As<IQueryHandler<GetUserGroupsQuery, IList<GroupDto>>>()
                .InstancePerDependency();

            builder.RegisterType<GetUserPermissionsQueryHandler>()
                .As<IQueryHandler<GetUserPermissionsQuery, List<GroupUserPermission>>>()
                .InstancePerDependency();

            builder.RegisterType<CreateMessageCommandHandler>()
                .As<ICommandHandler<CreateMessageCommand>>()
                .InstancePerDependency();

            builder.RegisterType<EditMessageCommandHandler>()
                .As<ICommandHandler<EditMessageCommand>>()
                .InstancePerDependency();

            builder.RegisterType<ReadMessageCommandHandler>()
                .As<ICommandHandler<ReadMessageCommand>>()
                .InstancePerDependency();

            builder.RegisterType<GetMessagesQueryHandler>()
                .As<IQueryHandler<GetMessagesQuery, IList<MessageDto>>>()
                .InstancePerDependency();

            builder.RegisterType<AuthenticateCommandHandler>()
                .As<ICommandHandlerWithResult<AuthenticateCommand, AuthenticationResult>>()
                .InstancePerDependency();

            builder.RegisterType<RegisterCommandHandler>()
                .As<ICommandHandler<RegisterCommand>>()
                .InstancePerDependency();

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

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces();
        }
    }
}
