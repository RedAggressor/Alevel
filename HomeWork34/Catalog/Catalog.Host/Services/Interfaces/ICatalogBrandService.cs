using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<IdResponse> AddAsync(string? type);
        Task<DeleteResponse> DeleteAsync(int? id);
        Task<UpdataResponse<CatalogBrandDto>> UpdateAsync(CatalogBrandDto? typeDto);
        Task<ListResponse<CatalogBrandDto>> GetList();
    }
}
