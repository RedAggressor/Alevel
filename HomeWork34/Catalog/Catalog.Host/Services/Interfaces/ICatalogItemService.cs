using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItemDto> GetCatalogItemsByIdAsync(int? id);
    Task<ICollection<CatalogItemDto>> GetCatalogItemByBrandAsync(int? idBrand);
    Task<ICollection<CatalogItemDto>> GetCatalogItemByTypeAsync(int? idType);
    Task<CatalogItemDto> UpdateAsync(CatalogItemDto catalogItemDto);
    Task<string> DeleteAsync(int? id);
}