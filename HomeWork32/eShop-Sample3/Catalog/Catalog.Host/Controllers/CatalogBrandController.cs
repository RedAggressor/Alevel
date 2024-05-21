using Catalog.Host.Models.Dtos;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<int> AddBrand(string type)
    {
        return await _service.AddAsync(type);
    }

    [HttpPut]
    public async Task<CatalogBrandDto> UpdateBrand(CatalogBrandDto catalogBrand)
    {
        return await _service.UpdateAsync(catalogBrand);
    }

    [HttpDelete]
    public async Task<string> DeleteBrand(int id)
    {
        return await _service.DeleteAsync(id);
    }
}