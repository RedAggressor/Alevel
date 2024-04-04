using HomeWork23.Datas;
using HomeWork23.Repositories;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Services;
using HomeWork23.Services.Abstracts;
using HomeWork23.Wrapper;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HomeWork23
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
                        option.UseSqlServer(connectionString));

                serviceCollection
                    .AddLogging(loggin => loggin.AddConsole())
                    .AddScoped<IDbContextWrapper<ApplicatDbContext>, DbContextWrapper<ApplicatDbContext>>()
                    .AddTransient<IPetRepository, PetRepository>()
                    .AddTransient<IPetService, PetService>()
                    .AddTransient<IBreedRepository, BreedRepository>()
                    .AddTransient<IBreedService, BreedService>()
                    .AddTransient<ICategoryRepository, CategoryRepository>()
                    .AddTransient<ICategoryService, CategoryService>()
                    .AddTransient<ILocationRepository, LocationRepository>()
                    .AddTransient<ILocationService, LocationService>()
                    .AddTransient<App>();
            }

            IConfiguration configur = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureService(serviceCollection, configur);
            var provaider = serviceCollection.BuildServiceProvider();

            var isNeedMigration = configur.GetSection("Migration").GetSection("IsNeedMigration");

            if (bool.Parse(isNeedMigration.Value))
            {
                var dbContext = provaider.GetService<ApplicatDbContext>();
                await dbContext!.Database.MigrateAsync();
            }
            var app = provaider.GetService<App>();
            await app!.Start();

        }
    }
}