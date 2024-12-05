using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<CatalogBrand?> GetById(int? id);
        Task<int?> AddAsync(string? brand);
        Task<string?> DeleteAsync(int? id);
        Task<CatalogBrand?> UpdateAsync(CatalogBrand? catalogBrand);
    }
}
