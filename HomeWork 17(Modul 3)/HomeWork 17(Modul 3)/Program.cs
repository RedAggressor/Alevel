using HomeWork_17_Modul_3_.Config;
using HomeWork_17_Modul_3_.Services;
using HomeWork_17_Modul_3_.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork_17_Modul_3_;

internal class Program
{
    static void Main(string[] args)
    {
        void ConfigurService(ServiceCollection servicesCollection, IConfiguration configuration)
        {
            servicesCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

            servicesCollection.AddSingleton<ILoggerService, LoggerService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigurService(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        app!.Start();

    }
}
