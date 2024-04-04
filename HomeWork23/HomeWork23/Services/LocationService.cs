using HomeWork23.Datas;
using HomeWork23.Models;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Services.Abstracts;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork23.Services
{
    internal class LocationService : BaseDataService<ApplicatDbContext>, ILocationService
    {
        private readonly ILogger<LocationService> _loggerService;
        private readonly ILocationRepository _repository;
        public LocationService(
            IDbContextWrapper<ApplicatDbContext> dbContextWrapper,
            ILogger<IBaseDataService> logger,
            ILogger<LocationService> loggerService,
            ILocationRepository locationRepository) 
            : base(dbContextWrapper, logger)
        {
            _loggerService = loggerService;
            _repository = locationRepository;
        }

        public async Task<int> AddLocationAsync(string name)
        { 
            var id = await _repository.AddLocationAsync(name);

            _loggerService.LogInformation($"Location seccusfull create id {id}");

            return id;
        }

        public async Task<Location> GetLocationAsync(int id)
        { 
            var entity = await _repository.GetLocationAsync(id);

            if (entity is null)
            {
                _loggerService.LogWarning("Location not finded");
                return null!;
            }

            _loggerService.LogInformation($"Location seccusfull get id {id}");

            return new Location()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public async Task<Location> UpdateLocationAsync(int id, string name)
        { 
            var entity = await _repository.UpdateLocationAsync(id, name);

            if (entity is null)
            {
                _loggerService.LogWarning("Location not finded");
                return null!;
            }

            _loggerService.LogInformation($"Location seccusfull update id {id}");

            return new Location()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public async Task<string> DeleteLocationAsync(int id)
        { 
            var message = await _repository.DeleteLocationAsync(id);

            if (message is null)
            {
                _loggerService.LogWarning("Location not finded");
                return null!;
            }

            _loggerService.LogInformation($"Location seccusfull delete id {id}");

            return message;
        }
    }
}
