using Basket.Host.Models;

namespace Basket.Host.Services.Abstractions;

public interface IBasketService
{
    Task TestAdd(string userId, string data);
    Task<TestGetResponse> TestGet(string userId);
}
