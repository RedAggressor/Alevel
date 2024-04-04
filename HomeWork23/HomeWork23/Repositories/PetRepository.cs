using HomeWork23.Datas;
using HomeWork23.Datas.Entities;
using HomeWork23.Dto;
using HomeWork23.Dto.Requests;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HomeWork23.Repositories
{
    internal class PetRepository : IPetRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public PetRepository(IDbContextWrapper<ApplicatDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddPetAsync(PetEntity pet)
        {
            var entity = await _dbContext.Pets.AddAsync(pet);

            await _dbContext.SaveChangesAsync();

            return entity.Entity.Id;
        }

        public async Task<PetEntity?> GetPetAsync(int id)
        {
            var entity = await _dbContext.Pets
                                .Include(x=>x.Breed!.Category)
                                .Include(x=>x.Category)
                                .Include (x=>x.Location)
                                .FirstOrDefaultAsync(x => x.Id == id);

            return entity is null ? null : entity;
        }

        public async Task<string> DeletePetAsync(int id)
        {
            var entity = await GetPetAsync(id);

            if(entity is null)
            {
                return null!;
            }

            var state = _dbContext.Pets.Remove(entity!);
            await _dbContext.SaveChangesAsync();

            return state.State.ToString();
        }

        public async Task<PetEntity> UpdatePetAsync(PetEntity petEntity)
        {
            var entity = await _dbContext.Pets
                                .Include(x=>x.Breed!.Category)
                                .Include(x=>x.Category)
                                .Include (x=>x.Location)
                                .FirstOrDefaultAsync(x => x.Id == petEntity.Id);

            if (entity is null)
            {
                return entity!;
            }

            entity.Age = petEntity.Age == -1 ? entity.Age : petEntity.Age;
            entity.Description = petEntity?.Description is null ? entity.Description : petEntity.Description;
            entity.ImageUrl = petEntity?.ImageUrl is null ? entity.ImageUrl : petEntity.ImageUrl;
            entity.Name = petEntity?.Name is null ? entity.Name : petEntity.Name;

            entity.Location = petEntity?.Location is null ? entity.Location : petEntity.Location;
            entity.LocationId = petEntity?.Location is null ? entity.LocationId : petEntity.LocationId;

            
            entity.BreedId = petEntity?.Breed is null ? entity.BreedId : petEntity.BreedId;
            entity.Breed = petEntity?.Breed is null ? entity.Breed : petEntity.Breed;
            entity.Breed!.Category = petEntity?.Breed?.Category is null ? entity.Breed.Category : petEntity.Breed.Category;

            entity.CategoryId = petEntity?.Category is null ? entity.CategoryId : petEntity.CategoryId;
            entity.Category = petEntity?.Category is null ? entity.Category : petEntity.Category;

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Responses<string, int>> GetPetPageAsync(PetRequest request)
        {
            var respons = new Responses<string, int>();
            
            respons.FiltrData = await _dbContext.Pets
                .Where(x => x.Location.Name == request.LocationCondition)
                .Where(x => x.Age > request.Age)
                .GroupBy(x=> x.Category.Name)
                .Select(g=> new {CategoryName = g.Key, BreedCount = g.Select(x => x.Breed.Name).Distinct().Count()})
                .ToDictionaryAsync(x=>x.CategoryName,y=>y.BreedCount);
                
            return respons;
        }
    }
}
