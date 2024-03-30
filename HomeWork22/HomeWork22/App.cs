using HomeWork22.Dtos;
using HomeWork22.Models;
using HomeWork22.Services.Abstracts;

namespace HomeWork22
{
    internal class App
    {
        private readonly IOrderService _orderService;
        private readonly ICostumerService _costumerService;
        private readonly IProductService _productService;
        public App(IProductService productService, ICostumerService costumerService, IOrderService orderService)
        {
            _costumerService = costumerService;
            _orderService = orderService;
            _productService = productService;
        }
        public async Task StartAsync()
        {
            var idConstumer = await _costumerService.AddCostumerAsync("Max", "Babych");

            var costumer = await _costumerService.GetCostumerAsync(idConstumer);

            costumer = await _costumerService.UpdateCostumerAsync(idConstumer, "Oleg");

            var idLimon = await _productService.AddProductAsync("Limon", 15.25);

            var idOrange = await _productService.AddProductAsync("Orange", 10.50);

            await _productService.UpdataProductAsync(idLimon, price: 11);

            var productLimon = await _productService.GetProductAsync(idLimon);

            var productOrange = await _productService.GetProductAsync(idOrange);

            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem()
                {
                     Count = 5,
                     Product = productLimon,
                     ProductId = productLimon.Id,
                },
                new OrderItem()
                {
                    Count = 10,
                    Product = productOrange,
                    ProductId = productOrange.Id,
                }
            };

            var idOrder = await _orderService.AddOrderAsync(idConstumer, orderItems);

            var order = await _orderService.GetOrderAsync(idOrder);

            var request = new RequestPage()
            {
                Name = "",
                PageNamber = 1,
                PageSize = 20,
                PriceMax = 10,
                PriceMin = 5,
            };

            await _productService.GetViewProductListAsync(request);

            await _orderService.DeleteOrderAsync(idOrder);

            await _costumerService.DeleteCostumerAsync(idConstumer);

            await _productService.DeleteProduct(idLimon);

            await _productService.DeleteProduct(idOrange);
        }
    }
}
