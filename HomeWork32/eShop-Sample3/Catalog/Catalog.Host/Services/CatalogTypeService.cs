using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _repository;
        private readonly IMapper _mapping;

        public CatalogTypeService(
            ICatalogTypeRepository repository,
            IMapper mapper,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogTypeService> logger)
            : base(dbContextWrapper, logger)
        {
            _repository = repository;
            _mapping = mapper;
        }

        public async Task<int> AddType(string type)
        {
            return await ExecuteSafeAsync(async () =>
            {                
                return await _repository.AddTypeAsync(type);
            });
        }

        public async Task<string> DeleteType(int id)
        {
            return await ExecuteSafeAsync(async() =>
            {
                return await _repository.DeleteType(id);
            });
        }

        public async Task<CatalogTypeDto> UpdateType(CatalogTypeDto typeDto)
        {
            return await ExecuteSafeAsync(async () => 
            {
                var entity = _mapping.Map<CatalogType>(typeDto);
                var upentity = await _repository.Update(entity);
                var dto = _mapping.Map<CatalogTypeDto>(upentity);
                return dto;
            });
        }
    }
}
