using HomeWork22.Datas.Entities;

namespace HomeWork22.Repositories.Abstractions
{
    internal interface ICostumerRepository
    {
        public Task<int> AddCostumerAsync(string lastname, string firstname);
        public Task<CostumerEntity> GetCostumerAsync(int id);
        public Task<CostumerEntity> UpdateCostumerAsync(
            int id,
            string lastname = null!,
            string firstname = null!);
        public Task<string> DeleteCostumerAsync(int id);
    }
}
