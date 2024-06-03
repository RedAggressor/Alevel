
namespace Catalog.Host.Models.Response;

public class PaginatedItemsResponse<T> : BaseResponce
{
    public int PageIndex { get; init; }

    public int PageSize { get; init; }

    public long Count { get; init; }

    public IEnumerable<T>? Data { get; init; }
      
    public override ResponceCode GetResponce() => Data is null ? ResponceCode.Null : ResponceCode.Seccusfull;
    
}
