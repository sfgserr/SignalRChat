﻿using Autofac;
using Domain.SessionProposals;
using Domain.Users;
using Infrastructure.Data;
using Infrastructure.Data.Domain.SessionProposals;
using Infrastructure.Data.Domain.Users;
using Infrastructure.Data.ValueConversion;
using Infrastructure.DomainEventsDispatching;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Configuration.Data
{
    internal class DataAccessModule : Module
    {
        private readonly string _connectionString;

        internal DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                DbContextOptionsBuilder optionsBuilder = new();
                optionsBuilder.UseSqlServer(_connectionString);

                optionsBuilder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                return new ApplicationContext(optionsBuilder.Options);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UsersCounter>()
                .As<IUsersCounter>()
                .FindConstructorsWith(new AllConstructorFinder())
                .InstancePerLifetimeScope();

            builder.RegisterType<SessionsCounter>()
                .As<ISessionsCounter>()
                .FindConstructorsWith(new AllConstructorFinder())
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
