using HomeWork22.Datas;
using HomeWork22.DbWrappers.Abstracts;
using HomeWork22.Dtos;
using HomeWork22.Models;
using HomeWork22.Repositories.Abstractions;
using HomeWork22.Services.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork22.Services
{
    internal class ProductService : BaseDataService<ApplicatDbContext>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(
            IProductRepository productRepository,
            ILogger<ProductService> loggerService,
            ILogger<BaseDataService<ApplicatDbContext>> logger,
            IDbContextWrapper<ApplicatDbContext> dbContextWrapper)
            : base
            (dbContextWrapper, logger)
        {
            _productRepository = productRepository;
            _logger = loggerService;
        }

        public async Task<int> AddProductAsync(string name, double price)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _productRepository.AddProductAsync(name, price);

                _logger.LogInformation($"Product succesfull create with id: {id}");

                return id;
            });
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var product = await _productRepository.GetProductAsync(id);

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
            });
        }

        public async Task<string> DeleteProduct(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var status = await _productRepository.DeleteProductAsync(id);

                if (status is null)
                {
                    _logger.LogWarning($"product don`t finded with id {id}");

                    return null!;
                }
                _logger.LogInformation($"Product seccesfull deleted: {id}");

                return status;
            });
        }

        public async Task<Product> UpdataProductAsync(int id, string name = null!, double price = 0)
        {
            var product = await _productRepository.UpdataProductAsync(id, name, price);
            if (product is null)
            {
                _logger.LogWarning("Product with this id don`t exist");

                return null!;
            }

            _logger.LogInformation($"Product with id: {id} seccusfull update");

            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }

        public async Task<IEnumerable<Product>> GetViewProductListAsync(RequestPage request)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var product = await _productRepository.GetProductListAsync(request);

                if (product is null)
                {
                    _logger.LogWarning("Product with this id don`t exist");

                    return null!;
                }

                return product.Select(x => new Product()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,

                }).ToList();
            });
        }
    }
}
