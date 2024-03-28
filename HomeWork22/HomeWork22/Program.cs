using HomeWork22.Datas;
using HomeWork22.Repositories;
using HomeWork22.Repositories.Abstractions;
using HomeWork22.Services;
using HomeWork22.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HomeWork22
{
    class Program
    {
        static async Task Main(string[] args)
        {
            void ConfigureService(ServiceCollection serviceCollection, IConfiguration configuration)
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                serviceCollection
                    .AddDbContextFactory<ApplicatDbContext>(option =>
                    option
                    .UseSqlServer(connectionString));
                // serviceColection.addwraper

                serviceCollection
                    .AddLogging(login => login.AddConsole())
                    .AddTransient<ICostumerRepository, CostumerRepository>()
                    .AddTransient<ICostumerService, CostumerService>()
                    .AddTransient<IOrderRepository, OrderRepository>()
                    .AddTransient<IOrderService, OrderService>()
                    .AddTransient<IProductRepository, ProductRepository>()
                    .AddTransient<IProductService, ProductService>()
                    .AddTransient<App>();
            }

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureService (serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var isNeedMigration = configuration
                .GetSection("Migration")
                .GetSection("IsNeedMigration");

            if (bool.Parse(isNeedMigration.Value!))
            {
                var dbContext = provider.GetService<ApplicatDbContext>();
                await dbContext!.Database.MigrateAsync();
            }

            var app = provider.GetService<App>();
            await app!.StartAsync();
        }
    }
}
