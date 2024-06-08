using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public Task<AddResponse> Add(
        string name,
        string description,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string pictureFileName)
    {


        return ExecuteSafeAsync(async () => new AddResponse() { Id = await _catalogItemRepository.Add(
            name,
            description,
            price,
            availableStock,
            catalogBrandId,
            catalogTypeId,
            pictureFileName)});
    }

    public async Task<CatalogItemDto> GetCatalogItemsByIdAsync(int? id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogItemRepository.GetCatalogItemsByIdAsync(id);

            var dto = _mapper.Map<CatalogItemDto>(item);

            return dto;
        });
        
    }

    public async Task<ListResponse<CatalogItemDto>> GetCatalogItemByBrandAsync(int? idBrand)
    {
        return await ExecuteSafeAsync(async () =>
        {            

            var itemColections = new List<CatalogItemDto>();

            var items = await _catalogItemRepository.GetCatalogItemsByBrandAsync(idBrand);

            itemColections.AddRange( items.Select(i => _mapper.Map<CatalogItemDto>(i)));

            return new ListResponse<CatalogItemDto>() 
            { 
                List = itemColections 
            };
        });
    }

    public async Task<ListResponse<CatalogItemDto>> GetCatalogItemByTypeAsync(int? idType)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var itemColections = new List<CatalogItemDto>();

            var items = await _catalogItemRepository.GetCatalogItemsByTypeAsync(idType);

            itemColections.AddRange(items.Select(i => _mapper.Map<CatalogItemDto>(i)));

            return new ListResponse<CatalogItemDto>()
            {
                List = itemColections
            };
        });
    }

    public async Task<DeleteResponse> DeleteAsync(int? id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var message = await _catalogItemRepository.DeleteAsync(id);
            return new DeleteResponse() 
            { 
                Status = message
            };
        });
    }

    public async Task<CatalogItemDto> UpdateAsync(CatalogItemDto catalogItemDto)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = _mapper.Map<CatalogItem>(catalogItemDto);
            item = await _catalogItemRepository.Update(item);
            var dto = _mapper.Map<CatalogItemDto>(item);

            return dto;
        });
    }

}