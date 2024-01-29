using Abstracts;
using Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstracts;

namespace HomeWork9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
            {
                serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

                serviceCollection.AddSingleton<ILoggerService, LoggerService>()
                                 .AddTransient<IAction, Action>()
                                 .AddSingleton<IFileService, FileService>()
                                 .AddTransient<App>();
            }

            IConfiguration configuration = new ConfigurationBuilder()
                                .AddJsonFile("config.json")
                                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            app!.Run();

        }
    }
}
