using HomeWork22.Models;

namespace HomeWork22.Services.Abstracts
{
    internal interface ICostumerService
    {
        public Task<int> AddCostumerAsync(string lastname, string firstname);
        public Task<Costumer> GetCostumerAsync(int id);
    }
}
