using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositoreis.Abstract;
using Repositoreis;
using Services.Abstract;
using Services;
using HomeWork8.Config;

namespace HomeWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
            {
                serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

                serviceCollection.AddTransient<ISaladBowlService, SaladBowlService>()
                    .AddTransient<ISaladBowlReposotory, SaladBowlRepository>()
                    .AddTransient<INotifyService, NotifyService>()
                    .AddSingleton<ILoggerService, LoggerService>()
                    .AddTransient<Menu>();
            }

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var menu = provider.GetService<Menu>();

            menu!.StartUp();
        }
    }
}
