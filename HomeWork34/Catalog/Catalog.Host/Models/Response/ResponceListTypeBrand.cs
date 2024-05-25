using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Models.Response
{
    public class ResponceListTypeBrand
    {
        public IEnumerable<CatalogBrandDto>? Brands { get; set; }
        public IEnumerable<CatalogTypeDto>? Types { get; set; }
    }
}
