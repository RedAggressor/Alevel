using HomeWork18.Dtos;
using HomeWork18.Dtos.Responses;
using HomeWork18.Models;

namespace HomeWork18.Services.Abstracts
{
    internal interface IUserService
    {
        public Task<User> GetUserAsync(int id);
        public Task<ListData<User>> GetUsersAsync(int page);
        public Task<Employee> CreateEmployeeAsync(string name, string job);
        public Task<Employee> UpdateEmployeeAsync(int id, string name, string job);
        public Task<Employee> ModifyEmployeeAsync(int id, string name, string job);
        public Task<VoidResult> DeleteEmployee(int id);
        public Task<ListData<User>> GetDelaiesUsersAsync(int page);
    }
}
