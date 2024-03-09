using HomeWork18.Config;
using HomeWork18.Dtos;
using HomeWork18.Dtos.Responses;
using HomeWork18.Enums;
using HomeWork18.Models;
using HomeWork18.Services.Abstracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HomeWork18.Services
{
    internal class UserService : BaseService, IUserService
    {
        private readonly IInternalHttpClientService _httpClient;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _apiOption;

        public UserService(
            IInternalHttpClientService internalHttpClientService,
            ILogger<UserService> logger,
            IOptions<ApiOption> apiOption)
        {
            _httpClient = internalHttpClientService;
            _logger = logger;
            _apiOption = apiOption.Value;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _httpClient
                    .SendAsync<SingleResponse<UserDto>>(
                        $"{_apiOption.Host}/{ApiType.users}/{id}",
                        HttpMethod.Get);

                if (result?.Data != null)
                {
                    _logger.LogInformation($"User with id = {result.Data.Id} was found");

                    return new User()
                    {
                        Id = result.Data.Id,
                        FirstName = result.Data.FirstName,
                        LastName = result.Data.LastName,
                        Email = result.Data.Email,
                        Avatar = result.Data.Avatar,
                    };
                }

                return null!;
            });
        }

        public async Task<ListData<User>> GetUsersAsync(int page)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _httpClient
                    .SendAsync<ListResponse<UserDto>>(
                        $"{_apiOption.Host}/{ApiType.users}?{ApiType.page}={page}",
                        HttpMethod.Get);

                if (result != null)
                {
                    _logger.LogInformation($"Users was found");

                    return new ListData<User>
                    {
                        Data = result.Data.Select(s => new User()
                        {
                            Id = s.Id,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            Avatar = s.Avatar,
                            Email = s.Email,
                        }).ToList(),
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> CreateEmployeeAsync(string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var employeeDto = new EmployeeDto()
                {
                    Name = name,
                    Job = job
                };

                var employee = await _httpClient
                    .SendAsync<EmployeeDto>(
                        $"{_apiOption.Host}/{ApiType.users}",
                        HttpMethod.Post,
                        employeeDto);

                if (employee != null)
                {
                    _logger.LogInformation($"Created user: {employee.Id}");

                    return new Employee()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Job = employee.Job,
                        CreatedAt = employee.CreatedAt,
                        UpdatedAt = employee.UpdatedAt,
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var employeeRequest = new EmployeeDto()
                {
                    Name = name,
                    Job = job,
                };

                var update = await _httpClient
                    .SendAsync<EmployeeDto>(
                        $"{_apiOption.Host}/{ApiType.users}/{id}",
                        HttpMethod.Put,
                        employeeRequest);

                if (update != null)
                {
                    _logger.LogInformation($"Employee was {update.Name} {update.Job} succefull update!!");

                    return new Employee()
                    {
                        Id = update.Id,
                        Name = update.Name,
                        Job = update.Job,
                        CreatedAt = update.CreatedAt,
                        UpdatedAt = update.UpdatedAt,
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> ModifyEmployeeAsync(int id, string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var changeData = new EmployeeDto()
                {
                    Name = name,
                    Job = job,
                };

                var update = await _httpClient
                    .SendAsync<EmployeeDto>(
                        $"{_apiOption.Host}/{ApiType.users}/{id}",
                        HttpMethod.Patch,
                        changeData);

                if (update != null)
                {
                    _logger.LogInformation($"Employee was {update.Name} {update.Job} modify succefull!!");

                    return new Employee()
                    {
                        Id = update.Id,
                        Name = update.Name,
                        Job = update.Job,
                        CreatedAt = update?.CreatedAt,
                        UpdatedAt = update?.UpdatedAt,
                    };
                }

                return null!;
            });
        }

        public async Task<VoidResult> DeleteEmployee(int id)
        {
            return await ExecuteSafeAsync<VoidResult>(async () =>
            {
                await _httpClient.SendAsync(
                        $"{_apiOption.Host}/{ApiType.users}/{id}",
                        HttpMethod.Delete);

                _logger.LogInformation($"User {id} was succefull delete!!");

                return null!;
            });
        }

        public async Task<ListData<User>> GetDelaiesUsersAsync(int page)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _httpClient.SendAsync<ListResponse<UserDto>>($"{_apiOption.Host}/{ApiType.users}?{ApiType.delay}={page}", HttpMethod.Get);

                if (result != null)
                {
                    _logger.LogInformation($"Delay was found");

                    return new ListData<User>()
                    {
                        Data = result.Data.Select(r => new User()
                        {
                            Id = r.Id,
                            FirstName = r.FirstName,
                            LastName = r.LastName,
                            Avatar = r.Avatar,
                            Email = r.Email,

                        }).ToList(),
                    };
                }

                return null!;
            });
        }
    }
}
