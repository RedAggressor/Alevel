using HomeWork10.Config;
using HomeWork10.Repositories;
using HomeWork10.Repositories.Abstructs;
using HomeWork10.Services;
using HomeWork10.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
            {
                serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

                serviceCollection.AddTransient<IBrendRepository,BrendRepository>()
                    .AddTransient<IInstrumentsRepository, InstrumentsRepository>()
                    .AddTransient<IInstrumentsService, InstrumentsService>()
                    .AddTransient<IRoomService, RoomService>()
                    .AddTransient<IRosetteService, RosetteService>()
                    .AddTransient<IHouseholdRepository, HouseholdRepository>()
                    .AddTransient<IHouseholdService, HouseholdService>()
                    .AddTransient<INotifyService, NotifyService>()
                    .AddSingleton<ILoggerService, LoggerService>()
                    .AddTransient<App>();
            }

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            app!.Start();
        }
    }
}
