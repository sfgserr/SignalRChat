using Application.UseCases.DeleteMessageUseCase;
using Application.UseCases.EditMessage;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args) =>
             CreateHostBuilder(args)
             .Build()
             .Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>());
    }
}