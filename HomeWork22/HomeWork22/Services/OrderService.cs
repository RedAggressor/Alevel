using HomeWork22.Models;
using HomeWork22.Repositories.Abstractions;
using HomeWork22.Services.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork22.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<int> AddOrderAsync(int costumerId, List<OrderItem> orderItems)
        {
            var id = await _orderRepository.AddOrderAsync(costumerId, orderItems);

            _logger.LogInformation($"Order seccusfull created with id {id}");

            return id;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrder(id);

            if (order is null)
            {
                _logger.LogWarning($"Order don`t finded with id {id}");
                return null!;
            }

            return new Order()
            {
                Id = order.Id,

                OrderItem = order.OrderItems.Select(s => new OrderItem()
                {
                    Count = s.Count,
                    ProductId = s.ProductId,

                    Product = new Product()
                    {
                        Id = s.Product.Id,
                        Name = s.Product.Name,
                        Price = s.Product.Price,
                    }
                })
            };
        }

        public async Task<IReadOnlyCollection<Order>> GetOrderByCostumerId(int id)
        {
            var order = await _orderRepository.GetOrderByCostumerId(id);

            if (order is null)
            {
                _logger.LogWarning($"Order not founded with id {id}");

                return null!;
            }

            return order.Select(s => new Order() 
            {
                Id = s.Id,
                OrderItem = s.OrderItems.Select(r => new OrderItem()
                {
                    Count = r.Count,
                    ProductId = r.ProductId,
                    Product = new Product()
                    { 
                        Id = r.Product.Id,
                        Name = r.Product.Name,
                        Price = r.Product.Price,
                    }
                })
            }).ToList();
        }
    }
}
