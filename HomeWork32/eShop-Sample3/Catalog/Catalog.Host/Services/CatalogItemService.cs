using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
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

    public Task<int?> Add(
        string name,
        string description,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string pictureFileName)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Add(
            name,
            description,
            price,
            availableStock,
            catalogBrandId,
            catalogTypeId,
            pictureFileName));
    }

    public async Task<CatalogItemDto> GetCatalogItemsByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogItemRepository.GetCatalogItemsByIdAsync(id);

            return _mapper.Map<CatalogItemDto>(item);
        });
        
    }

    public async Task<ICollection<CatalogItemDto>> GetCatalogItemByBrandAsync(int idBrand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var itemColections = new List<CatalogItemDto>();

            var items = await _catalogItemRepository.GetCatalogItemsByBrandAsync(idBrand);

            itemColections.AddRange( items.Select(i => _mapper.Map<CatalogItemDto>(i)));

            return itemColections;
        });
    }

    public async Task<ICollection<CatalogItemDto>> GetCatalogItemByTypeAsync(int idType)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var itemColections = new List<CatalogItemDto>();

            var items = await _catalogItemRepository.GetCatalogItemsByTypeAsync(idType);

            itemColections.AddRange(items.Select(i => _mapper.Map<CatalogItemDto>(i)));

            return itemColections;
        });
    }

    public async Task<string> DeleteAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return await _catalogItemRepository.DeleteAsync(id);
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