using HomeWork23.Models;

namespace HomeWork23.Services.Abstracts
{
    internal interface ILocationService
    {
        public Task<int> AddLocationAsync(string name);
        public Task<Location> GetLocationAsync(int id);
        public Task<Location> UpdateLocationAsync(int id, string name);
        public Task<string> DeleteLocationAsync(int id);
    }
}
