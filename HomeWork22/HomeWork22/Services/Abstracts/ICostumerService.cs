using HomeWork22.Models;

namespace HomeWork22.Services.Abstracts
{
    internal interface ICostumerService
    {
        public Task<int> AddCostumerAsync(string lastname, string firstname);
        public Task<Costumer> GetCostumerAsync(int id);
        public Task<Costumer> UpdateCostumerAsync(
            int id,
            string lastname = null!,
            string firstname = null!);
        public Task<string> DeleteCostumerAsync(int id);
    }
}
