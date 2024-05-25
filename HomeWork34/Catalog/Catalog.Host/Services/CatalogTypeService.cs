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

        public async Task<int?> AddType(string? type)
        {
            return await ExecuteSafeAsync(async () =>
            {
                if (type is null)
                {
                    return null;
                }

                return await _repository.AddTypeAsync(type);
            });
        }

        public async Task<IEnumerable<CatalogTypeDto>> GetList()
        {
            return await ExecuteSafeAsync(async () => 
            {
                var entity = await _repository.GetList();

                return entity.Select(s=>_mapping.Map<CatalogTypeDto>(s));                 
            });
        }

        public async Task<string?> DeleteType(int? id)
        {
            return await ExecuteSafeAsync(async() =>
            {
                if (id is null)
                {
                    return "Id can`t be null";
                }

                return await _repository.DeleteType(id);
            });
        }

        public async Task<CatalogTypeDto?> UpdateType(CatalogTypeDto typeDto)
        {
            return await ExecuteSafeAsync(async () => 
            {
                if (typeDto is null)
                {
                    return null;
                }

                var entity = _mapping.Map<CatalogType>(typeDto);
                var upentity = await _repository.Update(entity);
                var dto = _mapping.Map<CatalogTypeDto>(upentity);
                return dto;
            });
        }
    }
}
