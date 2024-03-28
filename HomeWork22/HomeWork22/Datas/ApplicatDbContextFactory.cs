using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HomeWork22.Datas
{
    internal class ApplicatDbContextFactory : IDesignTimeDbContextFactory<ApplicatDbContext>
    {
        public ApplicatDbContext CreateDbContext(string[] args)
        {
            var optionalBuilder = new DbContextOptionsBuilder<ApplicatDbContext>();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            
            var config = builder
                .AddJsonFile("config.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            optionalBuilder
                .UseSqlServer(connectionString, option => 
                    option
                    .CommandTimeout((int)TimeSpan
                    .FromMinutes(10)
                    .TotalSeconds));

            return new ApplicatDbContext(optionalBuilder.Options);
        }
    }
}
