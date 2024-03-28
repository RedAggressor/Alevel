using HomeWork22.Datas.Entities;

namespace HomeWork22.Repositories.Abstractions
{
    internal interface ICostumerRepository
    {
        public Task<int> AddCostumer(string lastname, string firstname);
        public Task<CostumerEntity> GetCostumer(int id);
    }
}
