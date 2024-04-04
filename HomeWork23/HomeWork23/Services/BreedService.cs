using HomeWork23.Datas;
using HomeWork23.Datas.Entities;
using HomeWork23.Models;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Services.Abstracts;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork23.Services
{
    internal class BreedService : BaseDataService<ApplicatDbContext>, IBreedService
    {
        private readonly ILogger<BreedService> _loggerService;
        private readonly IBreedRepository _repository;
        public BreedService(
            IDbContextWrapper<ApplicatDbContext> dbContextWrapper,
            ILogger<IBaseDataService> logger,
            IBreedRepository breedRepository,
            ILogger<BreedService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _loggerService = loggerService;
            _repository = breedRepository;
        }

        public async Task<int> AddBreedAsync(Breed breed)
        {
            var id = await _repository.AddBreedAsync(new BreedEntity()
            { 
                Name = breed.Name,
                Category = new CategoryEntity()
                { 
                    Name = breed.Category.Name                    
                }
            });

            _loggerService.LogInformation($"Breed seccusfull create id: {id}");
            return id;
        }

        public async Task<Breed> GetBreedAsync(int id)
        { 
            var entity = await _repository.GetBreedAsync(id);

            if (entity is null)
            {
                _loggerService.LogWarning("Breed not finded");
                return null!;
            }

            _loggerService.LogInformation($"Breed seccusfull get id: {id}");

            return new Breed()
            {
                Id = entity.Id,
                Name = entity.Name,
                CategoryId = entity.CategoryId,
                Category = new Category() 
                {
                    Id = entity.Category.Id,
                    Name = entity.Category.Name
                }
            };
        }

        public async Task<string> DeleteBreedAsync(int id)
        { 
            var message = await _repository.DeleteBreedAsync(id);
            if (message is null)
            {
                _loggerService.LogWarning("Breed not finded");
                return null!;
            }
            _loggerService.LogInformation($"Breed seccusfull get id: {id}");

            return message;
        }

        public async Task<Breed> UpdateBreedAsync(Breed breed)
        {
            var entity = new BreedEntity()
            {
                Id = breed.Id,
                Name = breed.Name,
                CategoryId = breed.CategoryId,
                Category = new CategoryEntity()
                { 
                    Id = breed.Category.Id,
                    Name = breed.Category.Name
                }
            };

            var entityUpdate = await _repository.UpdateBreedAsync(entity);

            if (entity is null)
            {
                _loggerService.LogWarning("Breed not finded");
                return null!;
            }

            return new Breed()
            {
                Id = entityUpdate.Id,
                Name = entityUpdate.Name,
                CategoryId = entityUpdate.CategoryId,
                Category = new Category()
                { 
                    Id = breed.Category.Id,
                    Name = breed.Category.Name
                } 
            };
        }
    }
}
