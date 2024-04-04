using HomeWork23.Datas.Entities;

namespace HomeWork23.Repositories.Abstracts
{
    internal interface ILocationRepository
    {
        public Task<int> AddLocationAsync(string name);
        public Task<LocationEntity?> GetLocationAsync(int id);
        public Task<LocationEntity> UpdateLocationAsync(int id, string name);
        public Task<string> DeleteLocationAsync(int id);
    }
}
