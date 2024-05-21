using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<int> AddAsync(string type);
        Task<string> DeleteAsync(int id);
        Task<CatalogBrandDto> UpdateAsync(CatalogBrandDto typeDto);
    }
}
