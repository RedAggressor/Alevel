using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _serivice;

    public CatalogTypeController(
        ILogger<CatalogTypeController> logger,
        ICatalogTypeService service)
    {
        _logger = logger;
        _serivice = service;
    }    

    [HttpPost]
    public async Task<int?> AddType(string? type)
    {
        if(type is null)
        {
            return null;
        }

        return await _serivice.AddType(type);
    }

    [HttpPut]
    public async Task<CatalogTypeDto?> UpdateType(CatalogTypeDto? catalogType)
    {
        if (catalogType is null)
        {
            return null;
        }

        return await _serivice.UpdateType(catalogType);
    }

    [HttpDelete]
    public async Task<string?> DeleteType(int? id)
    {
        if (id is null)
        {
            return "id can`t be null";
        }

        return await _serivice.DeleteType(id);
    }
}