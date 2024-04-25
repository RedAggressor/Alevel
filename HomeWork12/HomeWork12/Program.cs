using HomeWork12.Repositories;
using HomeWork12.Repositories.Abstractions;
using HomeWork12.Services;
using HomeWork12.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace HomeWork12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void ConfigreServices(ServiceCollection serviceCollection)
            {
                serviceCollection.AddTransient<IContactService, ContactService>()
                    .AddTransient<IContactRepository, ContactRepository>()
                    .AddTransient<StartUp>();
            }

            Console.OutputEncoding = UTF8Encoding.UTF8;

            var serviceCollection = new ServiceCollection();
            ConfigreServices(serviceCollection);
            var provider = serviceCollection.BuildServiceProvider();

            var start = provider.GetService<StartUp>();
            start!.Start();
        }
    }
}
