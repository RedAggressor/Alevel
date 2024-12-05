using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItem?> GetCatalogItemsByIdAsync(int id);
    Task<ICollection<CatalogItem>> GetCatalogItemsByBrandAsync(int idBrand);
    Task<ICollection<CatalogItem>> GetCatalogItemsByTypeAsync(int idType);
    Task<string> DeleteAsync(int id);
    Task<CatalogItem> Update(CatalogItem catalogItem);
}