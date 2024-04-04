using HomeWork23.Datas;
using HomeWork23.Datas.Entities;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HomeWork23.Repositories
{
    internal class LocationRepository : ILocationRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public LocationRepository(IDbContextWrapper<ApplicatDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddLocationAsync(string name)
        {
            var location = await _dbContext
                  .Locations
                  .AddAsync(new LocationEntity()
            {
                Name = name,
            });

            await _dbContext.SaveChangesAsync();

            return location.Entity.Id;
        }

        public async Task<LocationEntity?> GetLocationAsync(int id)
        {
            var entity = await _dbContext.Locations
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity is null ? null : entity;
        }

        public async Task<LocationEntity> UpdateLocationAsync(int id, string name)
        {
            var entity = await GetLocationAsync(id);

            if (entity is null)
            {
                return entity!;
            }

            entity.Name = name;

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<string> DeleteLocationAsync(int id)
        {
            var entity = await GetLocationAsync(id);

            if (entity is null)
            {
                return null;
            }

            var  status = _dbContext.Locations.Remove(entity!);

            await _dbContext.SaveChangesAsync();

            return status.State.ToString();
        }
    }
}
