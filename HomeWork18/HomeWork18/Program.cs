using HomeWork18;
using HomeWork18.Config;
using HomeWork18.Services;
using HomeWork18.Services.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{
    static async Task Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddHttpClient()
                .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        ServiceCollection serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        await app!.StartUp();
    }
}
