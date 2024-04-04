using HomeWork23.Datas;
using HomeWork23.Models;
using HomeWork23.Repositories.Abstracts;
using HomeWork23.Services.Abstracts;
using HomeWork23.Wrapper.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork23.Services
{
    internal class CategoryService : BaseDataService<ApplicatDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryService> _loggerService;

        public CategoryService(
            IDbContextWrapper<ApplicatDbContext> dbContextWrapper,
            ILogger<CategoryService> loggerService,
            ILogger<BaseDataService<ApplicatDbContext>> loggerBase,
            ICategoryRepository categoryRepository)
            : base(dbContextWrapper, loggerBase)
        {
            _repository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddCategoryAsync(string name)
        {
            var id = await _repository.AddCategory(name);

            _loggerService.LogInformation($"Category seccusfull create wuth id: {id}");

            return id;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var entity = await _repository.GetCategoryAsync(id);

            if (entity is null)
            {
                _loggerService.LogWarning("Category not finded");
                return null!;
            }

            _loggerService.LogInformation($"Category seccusfull get wuth id: {id}");

            return new Category()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public async Task<string> DeleteCategoryAsync(int id)
        {
            var message = await _repository.DeleteCategory(id);

            if (message is null)
            {
                _loggerService.LogWarning("Category not finded");
                return null!;
            }

            _loggerService.LogInformation($"Deleted category: {id}");

            return message;
        }

        public async Task<Category> UpdateCategory(int id, string name)
        {
            var entity = await _repository.UpdateCategoryAsync(id, name);

            if (entity is null)
            {
                _loggerService.LogWarning("Category not finded");
                return null!;
            }

            _loggerService.LogInformation($"Update succesfull category: {id}");

            return new Category()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
