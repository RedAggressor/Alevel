using HomeWork23.Datas.Entities;

namespace HomeWork23.Repositories.Abstracts
{
    internal interface IBreedRepository
    {
        public Task<BreedEntity> UpdateBreedAsync(BreedEntity breed);
        public Task<string> DeleteBreedAsync(int id);
        public Task<BreedEntity?> GetBreedAsync(int id);
        public Task<int> AddBreedAsync(BreedEntity breedEntity);
    }
}
