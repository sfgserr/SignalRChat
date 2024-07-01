﻿using Autofac;
using Infrastructure.DomainEventsDispatching;

namespace Infrastructure.Configuration.DomainEventsDispatching
{
    internal class DomainEventsDispatchingModule : Module
    {
        private readonly Dictionary<string, Type> _mappings;

        internal DomainEventsDispatchingModule(Dictionary<string, Type> mappings)
        {
            _mappings = mappings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventsDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DomainEventsAccessor>()
                .InstancePerLifetimeScope();

            builder.Register(c => new DomainEventsMapper(_mappings))
                .As<DomainEventsMapper>()
                .SingleInstance();
        }
    }
}
