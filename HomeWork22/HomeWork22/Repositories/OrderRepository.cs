using HomeWork22.Datas;
using HomeWork22.Datas.Entities;
using HomeWork22.DbWrappers.Abstracts;
using HomeWork22.Models;
using HomeWork22.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeWork22.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public OrderRepository(IDbContextWrapper<ApplicatDbContext> dbContextWrapper) 
        { 
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddOrderAsync(int id, List<OrderItemEntity> orderItemList)
        {
            var order = await _dbContext.Orders
                .AddAsync(new OrderEntity()
                { 
                    CostumerId = id,            
                });

            await _dbContext
                .OrderItems
                .AddRangeAsync(orderItemList.Select(s =>
                new OrderItemEntity()
                { 
                    Count = s.Count,
                    OrderId = order.Entity.Id,
                    ProductId = s.ProductId,                     
                }));

            await _dbContext.SaveChangesAsync();

            return order.Entity.Id;
        }

        public async Task<OrderEntity> UpDataOrderAsync(int id, List<OrderItemEntity> orderItem)
        {
            var orderUp = await GetOrder(id);
            
            orderUp.OrderItems = orderItem;

            await _dbContext.SaveChangesAsync();

            return orderUp;
        }

        public async Task<string> DeleteOrderAsync(int id)
        {
            var order = await GetOrder(id);

            if (order is null)
            {
                return null;
            }

            var status = _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync();
            return status.ToString();
        }

        public async Task<OrderEntity?> GetOrder(int id)
        {
            return await _dbContext.Orders
                .Include(i => i.OrderItems)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<OrderEntity>?> GetOrderByCostumerId(int id)
        {
            return await _dbContext.Orders
                .Include(x=>x.OrderItems)
                .Where(x=>x.CostumerId==id)
                .ToListAsync();
        }
    }
}
