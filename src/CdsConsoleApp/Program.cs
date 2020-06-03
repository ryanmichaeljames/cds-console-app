using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CdsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();

            var serviceProvider = new ServiceCollection()
                .Configure<CdsConfig>(configuration.GetSection(nameof(CdsConfig)))
                .AddTransient<CdsService, CdsService>()
                .AddSingleton<App, App>()
                .BuildServiceProvider();

            serviceProvider.GetService<App>().Run(args);
        }
    }
}
