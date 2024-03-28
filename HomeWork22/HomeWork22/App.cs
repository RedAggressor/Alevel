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
            var idConstumer = await _costumerService.AddCostumerAsync("Max", "Valerin");

            var costumer = await _costumerService.GetCostumerAsync(idConstumer);

            Console.WriteLine(costumer.Fullname);

            //await _orderService.AddOrderAsync();
            var idProduct = await _productService.AddProductAsync("Limon", 15.25);
        }   
    }
}
