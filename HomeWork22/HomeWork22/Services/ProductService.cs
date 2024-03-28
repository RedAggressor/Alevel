using HomeWork22.Models;
using HomeWork22.Repositories.Abstractions;
using HomeWork22.Services.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork22.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;        
        }

        public async Task<int> AddProductAsync(string name, double price)
        {
            var id = await _productRepository.AddProduct(name, price);

            _logger.LogInformation($"Product succesfull create with id: {id}");

            return id;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product is null)
            {
                _logger.LogWarning("Product with this id don`t exist");
                return null!;
            }

            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }
    }
}
