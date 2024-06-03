using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _service;

    public CatalogBrandController(ILogger<CatalogBrandController> logger, ICatalogBrandService catalogBrandService)
    {
        _logger = logger;
        _service = catalogBrandService;
    }

    [HttpPost]
    public async Task<IdResponse> AddBrand(string? brand)
    {        
        return await _service.AddAsync(brand);               
    }

    [HttpPut]
    public async Task<UpdataResponse<CatalogBrandDto>> UpdateBrand(CatalogBrandDto? catalogBrand)
    {
        return await _service.UpdateAsync(catalogBrand);
    }

    [HttpDelete]
    public async Task<DeleteResponse> DeleteBrand(int? id)
    {        
        return await _service.DeleteAsync(id);
    }
}