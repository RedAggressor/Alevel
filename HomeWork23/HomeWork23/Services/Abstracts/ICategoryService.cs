using HomeWork23.Models;

namespace HomeWork23.Services.Abstracts
{
    internal interface ICategoryService
    {
        public Task<int> AddCategoryAsync(string name);
        public Task<Category> GetCategoryAsync(int id);
        public Task<string> DeleteCategoryAsync(int id);
        public Task<Category> UpdateCategory(int id, string name);
    }
}
