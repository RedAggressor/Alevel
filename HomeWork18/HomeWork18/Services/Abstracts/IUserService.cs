using HomeWork18.Dtos;
using HomeWork18.Dtos.Responses;

namespace HomeWork18.Services.Abstracts
{
    internal interface IUserService
    {
        public Task<SingleResponse<UserDto>> GetUserAsync(int id);
        public Task<ListResponse<UserDto>> GetListUsersAsync(int page);
        public Task<ListResponse<ResourceDto>> GetListResourcesAsync();
        public Task<SingleResponse<ResourceDto>> GetResourceAsync(int id);
        public Task<UserCreateResponse> CreateUser(string name, string job);
        public Task<UpdateUserResponse> UpdateUserPutAsync(UserCreateResponse user);
        public Task<UpdateUserResponse> UpdateUserPathAsync(UserCreateResponse user);
        public Task<object> DeleteUser(int id);
        public Task<RegisterResponse> RegisterationAsync(string? email = null, string? password = null);
        public Task<LoginResponse> LoginAsync(string? email = null, string? password = null);
        public Task<ListResponse<DelayDto>> GetDelayAsync(int page);
    }
}
