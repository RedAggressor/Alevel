using HomeWork22.Datas.Entities;
using HomeWork22.Dtos;

namespace HomeWork22.Repositories.Abstractions
{
    internal interface IProductRepository
    {
        public Task<int> AddProductAsync(string name, double price);
        public Task<ProductEntity> GetProductAsync(int id);
        public Task DeleteProductAsync(int id);
        public Task<ProductEntity> UpdataProductAsync(
            int id,
            string name = null!, 
            double price = 0);

        public Task<IEnumerable<ProductEntity>> GetProductListAsync(RequestPage request);
    }
}
