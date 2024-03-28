using HomeWork22.Datas.Entities;

namespace HomeWork22.Repositories.Abstractions
{
    internal interface IProductRepository
    {
        public Task<int> AddProduct(string name, double price);
        public Task<ProductEntity> GetProduct(int id);
    }
}
