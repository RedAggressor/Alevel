using HomeWork23.Datas;
using HomeWork23.Datas.Entities;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HomeWork23.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public CategoryRepository(IDbContextWrapper<ApplicatDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddCategory(string name)
        {
            var entity = await _dbContext.Categories.AddAsync(new CategoryEntity()
            {
                Name = name
            });

            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(int id)
        {
            var entity = await _dbContext.Categories
                .FirstOrDefaultAsync(x=>x.Id == id);

            return entity is null ? null : entity;
        }

        public async Task<string> DeleteCategory(int id)
        { 
            var entity = await GetCategoryAsync(id);

            if (entity is null)
            {
                return null;
            }

            var status = _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return status.State.ToString();
        }

        public async Task<CategoryEntity> UpdateCategoryAsync(int id, string name)
        {
            var entity = await GetCategoryAsync(id);

            if (entity is null)
            {
                return null;
            }

            entity.Name = name;

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
