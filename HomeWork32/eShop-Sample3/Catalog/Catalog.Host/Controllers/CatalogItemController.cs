using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogItemService catalogItemService)
    {
        _logger = logger;
        _catalogItemService = catalogItemService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateProductRequest request)
    {
        var result = await _catalogItemService.Add(
            request.Name,
            request.Description,
            request.Price,
            request.AvailableStock,
            request.CatalogBrandId,
            request.CatalogTypeId,
            request.PictureFileName);

        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpGet]
    public async Task<CatalogItemDto> GetById(int id)
    {
        return await _catalogItemService.GetCatalogItemsByIdAsync(id);
    }

    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _catalogItemService.DeleteAsync(id);
    }

    [HttpPut]
    public async Task<CatalogItemDto> Update(CatalogItemDto catalogItemDto)
    {
        return await _catalogItemService.UpdateAsync(catalogItemDto);
    }
}