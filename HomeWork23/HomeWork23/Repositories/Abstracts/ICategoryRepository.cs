using HomeWork23.Datas.Entities;

namespace HomeWork23.Repositories.Abstracts
{
    internal interface ICategoryRepository
    {
        public Task<CategoryEntity> UpdateCategoryAsync(int id, string name);
        public Task<string> DeleteCategory(int id);
        public Task<CategoryEntity?> GetCategoryAsync(int id);
        public Task<int> AddCategory(string name);
    }
}
