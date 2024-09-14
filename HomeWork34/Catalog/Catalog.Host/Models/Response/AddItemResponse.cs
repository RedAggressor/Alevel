namespace Catalog.Host.Models.Response;

public class AddItemResponse<T> : BaseResponce
{
    public T? Id { get; set; }
}