using HomeWork22.Models;

namespace HomeWork22.Services.Abstracts
{
    internal interface IProductService
    {
        public Task<int> AddProductAsync(string name, double price);
        public Task<Product> GetProductAsync(int id);
    }
}
