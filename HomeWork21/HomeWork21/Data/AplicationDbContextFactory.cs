using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HomeWork21.Data
{
    internal class AplicationDbContextFactory : IDesignTimeDbContextFactory<AplicationDbContext>
    {
        public AplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AplicationDbContext>();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder
                .UseSqlServer(connectionString,
                option => option
                            .CommandTimeout((int)TimeSpan
                            .FromMinutes(10).TotalSeconds));

            return new AplicationDbContext(optionsBuilder.Options);
        }
    }
}