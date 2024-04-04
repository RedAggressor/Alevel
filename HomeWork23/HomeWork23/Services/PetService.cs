using HomeWork23.Datas;
using HomeWork23.Datas.Entities;
using HomeWork23.Dto;
using HomeWork23.Dto.Requests;
using HomeWork23.Models;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Services.Abstracts;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork23.Services
{
    internal class PetService : BaseDataService<ApplicatDbContext>, IPetService
    {
        private readonly ILogger<PetService> _loggerService;
        private readonly IPetRepository _repository;
        public PetService(
            IDbContextWrapper<ApplicatDbContext> dbContextWrapper,
            ILogger<IBaseDataService> logger,
            ILogger<PetService> loggerService,
            IPetRepository petRepository)
            : base(dbContextWrapper, logger)
        {
            _loggerService = loggerService;
            _repository = petRepository;
        }

        public async Task<int> AddPetAsync(Pet pet)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _repository.AddPetAsync(MapingToEntityAdd(pet));

                _loggerService.LogInformation($"Pet seccusfull create id : {id}");

                return id;
            });
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var entity = await _repository.GetPetAsync(id);

                if (entity is null)
                {
                    _loggerService.LogWarning($"Id not valid");
                    return null!;
                }

                _loggerService.LogInformation($"Pet seccusfull get id : {id}");
                return MapingToModel(entity);
            }); 
        }

        public async Task<string> DeletePetAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var message = await _repository.DeletePetAsync(id);
                if (message is null)
                {
                    _loggerService.LogWarning("id not valid");
                    return null!;
                }

                _loggerService.LogInformation($"Pet seccusfull delete id : {id}");
                return message;
            });
        }

        public async Task<Pet> UpdateAsync(Pet pet)
        {
            return await ExecuteSafeAsync(async() =>
            {
                var entity = MapingToEntityUpdate(pet);
                             

                var entityUpdate = await _repository.UpdatePetAsync(entity);

                if (entityUpdate is null)
                {
                    _loggerService.LogInformation($"Pet id : {pet.Id} not valid");
                    return null!;
                }

                _loggerService.LogInformation($"Pet seccusfull update id : {pet.Id}");
                return MapingToModel(entityUpdate);
            });
        }

        public async Task<Responses<string, int>> GetPetPageAsync(PetRequest request)
        {
            return await ExecuteSafeAsync(async() =>
            {
                return await _repository.GetPetPageAsync(request);
            });
        }        

        private Pet MapingToModel(PetEntity entity)
        {
            return new Pet()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Age = entity.Age,
                ImageUrl = entity.ImageUrl,
                CategoryId = entity.CategoryId,
                LocationId = entity.LocationId,
                BreedId = entity.BreedId,
                Category = new Category()
                {
                    Id = entity.Category.Id,
                    Name = entity.Category.Name
                },
                Breed = new Breed()
                {
                    Id = entity.Breed.Id,
                    Name = entity.Breed.Name,
                    Category = new Category()
                    {
                        Id = entity.Breed.Category.Id,
                        Name = entity.Breed.Category.Name
                    }
                },
                Location = new Location()
                {
                    Name = entity.Location.Name,
                    Id = entity.Location.Id
                }
            };
        }

        private PetEntity MapingToEntityUpdate(Pet pet)
        {
            return new PetEntity()
            {
                Id = pet.Id,
                Name = pet.Name,
                Description = pet.Description,
                Age = pet.Age,
                ImageUrl = pet.ImageUrl,
                CategoryId= pet.CategoryId,
                LocationId = pet.LocationId,
                BreedId = pet.BreedId,
                Category = new CategoryEntity()
                {
                    Id = pet.Category.Id,
                    Name = pet.Category.Name
                },
                Breed = new BreedEntity()
                {
                    Id = pet.Breed.Id,
                    Name = pet.Breed.Name,
                    Category = new CategoryEntity()
                    {
                        Id = pet.Breed.Category.Id,
                        Name = pet.Breed.Category.Name
                    }
                },
                Location = new LocationEntity()
                {
                    Id = pet.Location.Id,
                    Name = pet.Location.Name
                }
            };
        }

        private PetEntity MapingToEntityAdd(Pet pet)
        {
            return new PetEntity()
            {
                Name = pet.Name,
                Description = pet.Description,
                Age = pet.Age,
                ImageUrl = pet.ImageUrl,
                
                Category = new CategoryEntity()
                {
                    Name = pet.Category.Name
                },
                Breed = new BreedEntity()
                {
                    Name = pet.Breed.Name,
                    Category = new CategoryEntity()
                    {
                        Name = pet.Breed.Category.Name
                    }
                },
                Location = new LocationEntity()
                {
                    Name = pet.Location.Name
                }
            };
        }
    }
}
