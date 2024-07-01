using Autofac;
using Infrastructure.Data;
using Infrastructure.DomainEventsDispatching;
using Microsoft.EntityFrameworkCore;

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

                return new ApplicationContext(optionsBuilder.Options, c.Resolve<DomainEventsDispatcher>());
            })
            .AsSelf()
            .As<DbContext>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

            var infrastructureAssembly = typeof(ApplicationContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
