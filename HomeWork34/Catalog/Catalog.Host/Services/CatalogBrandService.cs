using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
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

        public async Task<IdResponse> AddAsync(string? brand)
        {
            return await ExecuteSafeAsync(async () =>
            {                
                var entity = await _repository.AddAsync(brand);
                return new IdResponse()
                {
                    Id = entity.Value
                };
            });
        }

        public async Task<ListResponse<CatalogBrandDto>> GetList()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var entity = await _repository.GetList();
                var dto = entity.Select(s=>_mapper.Map<CatalogBrandDto>(s)).ToList();

                return new ListResponse<CatalogBrandDto>() 
                { 
                    List = dto
                };
            });
        }

        public async Task<DeleteResponse> DeleteAsync(int? id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var responce = await _repository.DeleteAsync(id);

                return new DeleteResponse() 
                { 
                    Status = responce
                };
            });
        }

        public async Task<UpdataResponse<CatalogBrandDto>> UpdateAsync(CatalogBrandDto? brandDto)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var entity = _mapper.Map<CatalogBrand>(brandDto);
                var upentity = await _repository.UpdateAsync(entity);
                var dto = _mapper.Map<CatalogBrandDto>(upentity);

                return new UpdataResponse<CatalogBrandDto>
                {
                    UpdataModel = dto    
                };
            });
        }
    }
}
