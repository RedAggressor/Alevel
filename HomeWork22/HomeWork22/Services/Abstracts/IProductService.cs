using HomeWork22.Dtos;
using HomeWork22.Models;

namespace HomeWork22.Services.Abstracts
{
    internal interface IProductService
    {
        public Task<int> AddProductAsync(string name, double price);
        public Task<Product> GetProductAsync(int id);
        public Task<int> UpdataProductAsync(int id, string name = null!, double price = 0);
        public Task DeleteProduct(int id);
        public Task<IEnumerable<Product>> GetViewProductListAsync(RequestPage request);
    }
}
