using HomeWork22.Datas;
using HomeWork22.Datas.Entities;
using HomeWork22.DbWrappers.Abstracts;
using HomeWork22.Models;
using HomeWork22.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeWork22.Repositories
{
    internal class CostumerRepository : ICostumerRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public CostumerRepository(IDbContextWrapper<ApplicatDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddCostumerAsync(string lastname, string firstname)
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

        public async Task<CostumerEntity> UpdateCostumerAsync(int id, string lastname = null!, string firstname = null!)
        {
            var costumer = await GetCostumerAsync(id);

            costumer.LastName = lastname is null ? costumer.LastName : lastname;

            costumer.FirstName = firstname is null ? costumer.FirstName : firstname;

            await _dbContext.SaveChangesAsync();

            return costumer;
        }

        public async Task DeleteCostumerAsync(int id)
        {
            var costumer = await GetCostumerAsync(id);

            _dbContext.Costumers.Remove(costumer);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<CostumerEntity> GetCostumerAsync(int id)
        {
            return await _dbContext.Costumers.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
