using HomeWork21.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeWork21
{
    internal class App
    {
        private readonly AplicationDbContext _dbContext;

        public App(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task StartUpAsync()
        {
            var data = await _dbContext.Pets.ToListAsync();
            foreach (var location in data) 
            {
                Console.WriteLine(location.Id + " " + location.Name);
            }
            
        }
    }
}
