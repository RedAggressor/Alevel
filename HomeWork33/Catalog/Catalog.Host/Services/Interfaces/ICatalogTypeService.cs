using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<CatalogTypeDto?> UpdateType(CatalogTypeDto typeDto);
        Task<string?> DeleteType(int? id);
        Task<int?> AddType(string? type);
    }
}
