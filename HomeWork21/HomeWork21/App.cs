using HomeWork21.Data;
using HomeWork21.Models;
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

            List<Pet> pets = new List<Pet>();

            var data = await _dbContext.Pets.ToListAsync();

            foreach (var pet in data)
            {
                pets.Add(
                    new Pet()
                    {
                        Id = pet.Id,
                        Name = pet.Name,
                        Age = pet.Age,
                        Discription = pet.Description,
                        ImageUrl = pet.ImageUrl,

                        Category = new Category()
                        {
                            Id = pet.Category.Id,
                            Name = pet.Category.CategoryName,
                        },

                        Breed = new Breed()
                        {
                            Id = pet.Breed.Id,
                            Name = pet.Breed.BreedName,
                            
                            Category = new Category()
                            {
                                Id = pet.Category.Id,
                                Name = pet.Category.CategoryName,
                            },
                        },

                        Location = new Location() 
                        { 
                            Id = pet.Location.Id,
                            Name = pet.Location.LocationName
                        }
                        
                    });
            }
        }
    }
}
