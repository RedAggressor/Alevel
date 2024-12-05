using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> Add(
        string name,
        string description,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<CatalogItem?> GetCatalogItemsByIdAsync(int idItem)
    {
       return await _dbContext.CatalogItems
            .Include(i => i.CatalogType)
            .Include(i=>i.CatalogBrand)
            .FirstOrDefaultAsync(item => item.Id == idItem);
    }

    public async Task<ICollection<CatalogItem>> GetCatalogItemsByBrandAsync(int idBrand)
    {
        return await _dbContext.CatalogItems
            .Include(i=>i.CatalogType)
            .Include(i => i.CatalogBrand)
            .Select(item => item)
            .Where(item => item.CatalogBrand.Id == idBrand)
            .ToListAsync();
    }

    public async Task<ICollection<CatalogItem>> GetCatalogItemsByTypeAsync(int idType)
    {
        return await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .Select(item => item)
            .Where(item => item.CatalogType.Id == idType)
            .ToListAsync();
    }

    public async Task<string> DeleteAsync(int id)
    {
        var item = await GetCatalogItemsByIdAsync(id);
        var message = _dbContext.CatalogItems.Remove(item!);
        await _dbContext.SaveChangesAsync();
        return message.State.ToString();
    }

    public async Task<CatalogItem> Update(CatalogItem catalogItem)
    {
        var item = await GetCatalogItemsByIdAsync(catalogItem.Id);

        item!.Price = catalogItem.Price;
        item.Description = catalogItem.Description;
        item.PictureFileName = catalogItem.PictureFileName;
        item.Name = catalogItem.Name;
        item.AvailableStock = catalogItem.AvailableStock;
        item.CatalogBrandId = catalogItem.CatalogBrandId;
        item.CatalogType = catalogItem.CatalogType;
        item.CatalogTypeId = catalogItem.CatalogTypeId;
        item.CatalogBrand = catalogItem.CatalogBrand;

        await _dbContext.SaveChangesAsync();

        return item;
    }
}