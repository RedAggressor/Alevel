using HomeWork22.Datas.Entities;
using HomeWork22.Models;

namespace HomeWork22.Repositories.Abstractions
{
    internal interface IOrderRepository
    {
        public Task<int> AddOrderAsync(int id, List<OrderItem> orderItemList);
        public Task<OrderEntity?> GetOrder(int id);
        public Task<IEnumerable<OrderEntity>?> GetOrderByCostumerId(int id);
        public Task<OrderEntity> UpDataOrderAsync(int id, List<OrderItemEntity> orderItem);
        public Task<string> DeleteOrderAsync(int id);
    }
}
