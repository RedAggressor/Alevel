using HomeWork22.Datas;
using HomeWork22.Datas.Entities;
using HomeWork22.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeWork22.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public ProductRepository(ApplicatDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<int> AddProduct(string name, double price)
        {
            var product = new ProductEntity()
            {
                Name = name,
                Price = price
            };

            var products = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return products.Entity.Id;
        }

        public async Task<ProductEntity> GetProduct(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(consumers => consumers.Id == id);
        }
    }
}
