using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _repository;
        private readonly IMapper _mapper;
        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogBrandService> logger,
            ICatalogBrandRepository catalogBrandRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        { 
            _repository = catalogBrandRepository;
            _mapper = mapper;
        }

        public async Task<int?> AddAsync(string? brand)
        {
            return await ExecuteSafeAsync(async () =>
            {
                if(brand is null)
                {
                    return null;
                }
                return await _repository.AddAsync(brand);
            });
        }

        public async Task<IEnumerable<CatalogBrandDto>> GetList()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var entity = await _repository.GetList();
                var dto = entity.Select(s=>_mapper.Map<CatalogBrandDto>(s)).ToList();

                return dto;
            });
        }

        public async Task<string?> DeleteAsync(int? id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                if(id is null)
                {
                    return "Id can`t be null";
                }

                return await _repository.DeleteAsync(id);
            });
        }

        public async Task<CatalogBrandDto?> UpdateAsync(CatalogBrandDto? brandDto)
        {
            return await ExecuteSafeAsync(async () =>
            {
                if(brandDto is null)
                {
                    return null;
                }

                var entity = _mapper.Map<CatalogBrand>(brandDto);
                var upentity = await _repository.UpdateAsync(entity);
                var dto = _mapper.Map<CatalogBrandDto>(upentity);
                return dto;
            });
        }
    }
}
