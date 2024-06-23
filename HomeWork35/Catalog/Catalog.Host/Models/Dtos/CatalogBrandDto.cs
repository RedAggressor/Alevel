namespace Catalog.Host.Models.Dtos;

public class CatalogBrandDto : BaseResponce
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;
}