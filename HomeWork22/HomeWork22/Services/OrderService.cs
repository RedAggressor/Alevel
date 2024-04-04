using HomeWork22.Datas;
using HomeWork22.Datas.Entities;
using HomeWork22.DbWrappers.Abstracts;
using HomeWork22.Models;
using HomeWork22.Repositories.Abstractions;
using HomeWork22.Services.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork22.Services
{
    internal class OrderService : BaseDataService<ApplicatDbContext>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(
            IOrderRepository orderRepository,
            ILogger<OrderService> loggerService,
            ILogger<BaseDataService<ApplicatDbContext>> logger,
            IDbContextWrapper<ApplicatDbContext> dbContextWrapper)
            : base
            (dbContextWrapper, logger)
        {
            _orderRepository = orderRepository;
            _logger = loggerService;
        }

        public async Task<int> AddOrderAsync(int costumerId, List<OrderItem> orderItems)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _orderRepository.AddOrderAsync(costumerId, orderItems);

                _logger.LogInformation($"Order seccusfull created with id {id}");

                return id;
            });

        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await ExecuteSafeAsync(async() =>
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
            });
        }

        public async Task<string> DeleteOrderAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var status = await _orderRepository.DeleteOrderAsync(id);

                if (status is null)
                {
                    _logger.LogWarning($"Order don`t finded with id {id}");

                    return null!;
                }

                _logger.LogInformation($"Order {id} is seccusfull delete");
                return status;
            });
        }

        public async Task<Order> UpdateOrderAsync(int id, List<OrderItem> items)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var entity = items.Select(s => new OrderItemEntity()
                {
                    Count = s.Count,
                    ProductId = s.ProductId,
                    Product = new ProductEntity()
                    {
                        Id = s.Product.Id,
                        Name = s.Product.Name,
                        Price = s.Product.Price,
                    }
                }).ToList();

                var order = await _orderRepository.UpDataOrderAsync(id, entity);
                if (order is null)
                {
                    _logger.LogWarning($"Order don`t finded with id {id}");

                    return null!;
                }

                _logger.LogInformation($"Update succesfull {order.Id}");

                return new Order()
                {
                    Id = order.Id,
                    Costumer = new Costumer()
                    {
                        Id = order.Costumer.Id,
                        Firstname = order.Costumer.FirstName,
                        Lastname = order.Costumer.LastName,
                        Fullname = $"{order.Costumer.FirstName} {order.Costumer.LastName}"
                    },
                    OrderItem = new List<OrderItem>().Select(s => new OrderItem()
                    {
                        Count = s.Count,
                        Product = s.Product,
                        ProductId = s.ProductId
                    }),
                };
            });
        }

        public async Task<IReadOnlyCollection<Order>> GetOrderByCostumerId(int id)
        {
            return await ExecuteSafeAsync(async () =>
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
            });
        }
    }
}
