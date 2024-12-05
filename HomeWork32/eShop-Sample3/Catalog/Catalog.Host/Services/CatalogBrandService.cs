using AutoMapper;
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

        public async Task<int> AddAsync(string type)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _repository.AddAsync(type);
            });
        }

        public async Task<string> DeleteAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _repository.DeleteAsync(id);
            });
        }

        public async Task<CatalogBrandDto> UpdateAsync(CatalogBrandDto typeDto)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var entity = _mapper.Map<CatalogBrand>(typeDto);
                var upentity = await _repository.UpdateAsync(entity);
                var dto = _mapper.Map<CatalogBrandDto>(upentity);
                return dto;
            });
        }
    }
}
