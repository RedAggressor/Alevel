using HomeWork23.Models;

namespace HomeWork23.Services.Abstracts
{
    internal interface IBreedService
    {
        public Task<Breed> UpdateBreedAsync(Breed breed);
        public Task<string> DeleteBreedAsync(int id);
        public Task<Breed> GetBreedAsync(int id);
        public Task<int> AddBreedAsync(Breed breed);
    }
}
