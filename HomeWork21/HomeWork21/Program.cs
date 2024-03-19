using HomeWork21;
using HomeWork21.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

class Program
{
    static async Task Main(string[] args)
    {
        void ConfigureService(ServiceCollection serviceCollection, IConfiguration confuration)
        {
            var conectionString = confuration.GetConnectionString("DefaultConnection");
            serviceCollection
                .AddDbContext<AplicationDbContext>
                (o => o.UseSqlServer(conectionString));

            serviceCollection
                .AddLogging(log => log.AddConsole())
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var services = new ServiceCollection();
        ConfigureService(services, configuration);
        var provider = services.BuildServiceProvider();

        var migrationSection = configuration.GetSection("Migration");
        var isNeedMigration = migrationSection.GetSection("IsNeedMigration");
        
        if (bool.Parse(isNeedMigration.Value!))
        {
            var dbContext = provider.GetService<AplicationDbContext>();
            await dbContext!.Database.MigrateAsync();
        }

        var app = provider.GetService<App>();
        await app!.StartUpAsync();
    }
}
