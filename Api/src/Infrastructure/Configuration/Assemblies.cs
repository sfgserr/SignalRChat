using Application.Cqrs.Commands;
using System.Reflection;

namespace Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(ICommandHandler<>).Assembly;
    }
}
