using HomeWork22.Datas;
using HomeWork22.Datas.Entities;
using HomeWork22.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeWork22.Repositories
{
    internal class CostumerRepository : ICostumerRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public CostumerRepository(ApplicatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCostumer(string lastname, string firstname)
        {
            var costumer = new CostumerEntity()
            {
                FirstName = firstname,
                LastName = lastname
            };

            var costm = await _dbContext.AddAsync(costumer);
            await _dbContext.SaveChangesAsync();

            return costm.Entity.Id;
        }

        //public async Task<int> UpdateCostumers()
        //{ 
            
        //}

        public async Task<CostumerEntity> GetCostumer(int id)
        {
            return await _dbContext.Costumers.FirstOrDefaultAsync(c=>c.Id == id);             
        }
    }
}
