using HomeWork23.Datas;
using HomeWork23.Datas.Entities;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HomeWork23.Repositories
{
    internal class BreedRepository : IBreedRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public BreedRepository(IDbContextWrapper<ApplicatDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddBreedAsync(BreedEntity breedEntity)
        { 
            var breed = await _dbContext.Breeds.AddAsync(breedEntity);
            await _dbContext.SaveChangesAsync();

            return breed.Entity.Id;
        }

        public async Task<BreedEntity?> GetBreedAsync(int id)
        {
            var entity = await _dbContext.Breeds
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity is null ? null : entity;
        }

        public async Task<string> DeleteBreedAsync(int id)
        { 
            var entity = await GetBreedAsync(id);

            if (entity is null)
            {
                return null;
            }

            var status = _dbContext.Breeds.Remove(entity);

            await _dbContext.SaveChangesAsync();
            return status.State.ToString();
        }

        public async Task<BreedEntity> UpdateBreedAsync(BreedEntity breed)
        {
            var entity = await GetBreedAsync(breed.Id);

            if (entity is null)
            {
                return null;
            }

            entity.Name = breed.Name is null ? entity.Name : breed.Name;
            entity.Category = breed.Category is null ? entity.Category : breed.Category;
            entity.CategoryId = breed.Category is null ? entity.CategoryId : breed.CategoryId;

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
