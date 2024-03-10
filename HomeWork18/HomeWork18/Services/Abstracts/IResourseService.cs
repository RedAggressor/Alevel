using HomeWork18.Models;

namespace HomeWork18.Services.Abstracts
{
    internal interface IResourseService
    {
        public Task<ListData<Resource>> GetListResourcesAsync();
        public Task<Resource> GetResourceAsync(int id);
    }
}
