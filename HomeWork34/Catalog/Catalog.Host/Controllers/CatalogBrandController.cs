using Catalog.Host.Data.Entities;
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
    public async Task<int?> AddBrand(string? brand)
    {
        if (brand is null)
        {
            return null;
        }
        return await _service.AddAsync(brand);
    }

    [HttpPut]
    public async Task<CatalogBrandDto?> UpdateBrand(CatalogBrandDto? catalogBrand)
    {
        if(catalogBrand is null)
        {
            return null;
        }
        return await _service.UpdateAsync(catalogBrand);
    }

    [HttpDelete]
    public async Task<string?> DeleteBrand(int? id)
    {
        if (id is null)
        {
            return null;
        }
        return await _service.DeleteAsync(id);
    }
}