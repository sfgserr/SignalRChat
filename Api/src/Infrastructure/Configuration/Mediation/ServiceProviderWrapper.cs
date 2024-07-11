using Autofac;

namespace Infrastructure.Configuration.Mediation
{
    internal class ServiceProviderWrapper : IServiceProvider
    {
        private readonly ILifetimeScope _lifeTimeScope;

        internal ServiceProviderWrapper(ILifetimeScope lifeTimeScope)
        {
            _lifeTimeScope = lifeTimeScope;
        }

        public object? GetService(Type serviceType) => 
            _lifeTimeScope.ResolveOptional(serviceType);
    }
}
