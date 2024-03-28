using HomeWork22.Models;

namespace HomeWork22.Services.Abstracts
{
    internal interface IOrderService
    {
        public Task<int> AddOrderAsync(int costumerId, List<OrderItem> orderItems);
        public Task<Order> GetOrderAsync(int id);
        public Task<IReadOnlyCollection<Order>> GetOrderByCostumerId(int id);
    }
}
