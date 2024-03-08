using HomeWork18.Config;
using HomeWork18.Dtos;
using HomeWork18.Dtos.Requests;
using HomeWork18.Dtos.Responses;
using HomeWork18.Services.Abstracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HomeWork18.Services
{
    internal class UserService : IUserService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _apiOption;
        private const string? _userApi = "api/users";
        private const string? _sourceApi = "api/unknown";
        private const string? _registerApi = "api/register";
        private const string? _loginApi = "api/login";

        public UserService(
            IInternalHttpClientService internalHttpClientService,
            ILogger<UserService> logger,
            IOptions<ApiOption> apiOption)
        {
            _httpClientService = internalHttpClientService;
            _logger = logger;
            _apiOption = apiOption.Value;
        }

        public async Task<SingleResponse<UserDto>> GetUserAsync(int id)
        {
            var result = await _httpClientService
                .SendAsync<SingleResponse<UserDto>, object>(
                    $"{_apiOption.Host}{_userApi}/{id}",
                    HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"User with id = {result.Data.Id} was found");
            }

            return result;
        }

        public async Task<ListResponse<UserDto>> GetListUsersAsync(int page)
        {
            var result = await _httpClientService
                .SendAsync<ListResponse<UserDto>, object>(
                    $"{_apiOption.Host}{_userApi}?page={page}",
                    HttpMethod.Get);

            if (result != null)
            {
                _logger.LogInformation($"Users was found");
            }

            return result;
        }

        public async Task<ListResponse<ResourceDto>> GetListResourcesAsync()
        {
            var result = await _httpClientService
                .SendAsync<ListResponse<ResourceDto>, object>(
                    $"{_apiOption.Host}{_sourceApi}",
                    HttpMethod.Get);

            if (result != null)
            {
                _logger.LogInformation($"Source was found");
            }

            return result;
        }

        public async Task<SingleResponse<ResourceDto>> GetResourceAsync(int page)
        {
            var result = await _httpClientService
                .SendAsync<SingleResponse<ResourceDto>, object>(
                    $"{_apiOption.Host}{_sourceApi}/{page}",
                    HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Source with id = {result.Data.Id} was found");
            }

            return result;
        }

        public async Task<UserCreateResponse> CreateUser(string name, string job)
        {
            var user = new UserRequest()
            {
                Name = name,
                Job = job
            };

            var result = await _httpClientService
                .SendAsync<UserCreateResponse, UserRequest>(
                    $"{_apiOption.Host}{_userApi}",
                    HttpMethod.Post,
                    user);

            if (result != null)
            {
                _logger.LogInformation($"Created user: {result.Id}");
            }

            return result;
        }

        public async Task<UpdateUserResponse> UpdateUserPutAsync(UserCreateResponse user)
        {
            var changeData = new UserRequest()
            {
                Name = user.Name,
                Job = user.Job,
            };

            var update = await _httpClientService
                .SendAsync<UpdateUserResponse, UserRequest>(
                    $"{_apiOption.Host}{_userApi}/{user.Id}",
                    HttpMethod.Put,
                    changeData);

            if (update != null)
            {
                _logger.LogInformation($"User was {user.Name} {user.Job} succefull update!!");
            }

            return update;
        }

        public async Task<UpdateUserResponse> UpdateUserPathAsync(UserCreateResponse user)
        {
            var changeData = new UserRequest()
            {
                Name = user.Name,
                Job = "zion resident123",
            };

            var update = await _httpClientService
                .SendAsync<UpdateUserResponse, UserRequest>(
                    $"{_apiOption.Host}{_userApi}/{user.Id}",
                    HttpMethod.Patch,
                    changeData);

            if (update != null)
            {
                _logger.LogInformation($"User was {user.Name} {user.Job} succefull update!!");
            }

            return update;
        }

        public async Task<object> DeleteUser(int id)
        {
            var delete = await _httpClientService
                .SendAsync<UpdateUserResponse, UserRequest>(
                    $"{_apiOption.Host}{_userApi}/{id}",
                    HttpMethod.Delete);

            if (delete == null)
            {
                _logger.LogInformation($"User {id} was succefull delete!!");
            }

            return delete;
        }

        public async Task<RegisterResponse> RegisterationAsync(string? email = null, string? password = null)
        {
            var registration = new RegisterRequest()
            {
                Email = email,
                Password = password
            };

            var regist = await _httpClientService
                .SendAsync<RegisterResponse, RegisterRequest>(
                $"{_apiOption.Host}{_registerApi}",
                HttpMethod.Post,
                registration);

            if (regist != null)
            {
                _logger.LogInformation($"Acount {registration.Email} {regist.Id} succesfull create ");
            }
            else
            {
                _logger.LogError("Missing email or password");
            }
            
            return regist;
        }

        public async Task<LoginResponse> LoginAsync(string? email = null, string? password = null)
        {
            var login = new LoginRequest()
            {
                Email = email,
                Password = password
            };

            var regist = await _httpClientService
                .SendAsync<LoginResponse, LoginRequest>(
                $"{_apiOption.Host}{_loginApi}",
                HttpMethod.Post,
                login);

            if (regist != null)
            {
                _logger.LogInformation($"Acount {login.Email} succesfull login ");
            }
            else
            {
                _logger.LogError("Missing email or password");
            }

            return regist;
        }

        public async Task<ListResponse<DelayDto>> GetDelayAsync(int page)
        {
            var result = await _httpClientService.SendAsync<ListResponse<DelayDto>, object>($"{_apiOption.Host}{_userApi}?delay={page}", HttpMethod.Get);

            if (result != null)
            {
                _logger.LogInformation($"Delay was found");
            }

            return result;
        }
    }
}
