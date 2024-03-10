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
    internal class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly ApiOption _apiOption;
        private readonly IInternalHttpClientService _httpClient;

        public AuthenticationService(ILogger<AuthenticationService> logger, IOptions<ApiOption> apiOption, IInternalHttpClientService internalHttpClientService)
        {
            _logger = logger;
            _apiOption = apiOption.Value;
            _httpClient = internalHttpClientService;
        }

        public async Task<Register> RegisterAsync(string? email, string? password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var registration = new AuthorDto()
                {
                    Email = email,
                    Password = password
                };

                var registToken = await _httpClient
                    .SendAsync<RegisterResponse>(
                    $"{_apiOption.Host}/{ApiType.register}",
                    HttpMethod.Post,
                    registration);

                if (registToken != null)
                {
                    _logger.LogInformation($"Acount {registration.Email} {registToken.Id} succesfull create ");
                }
                else
                {
                    _logger.LogError("something going wrong!");
                }

                return new Register()
                {
                    Id = registToken!.Id!,
                    Token = registToken!.Token!,
                };
            });
        }

        public async Task<Login> LoginAsync(string? email, string? password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var login = new AuthorDto()
                {
                    Email = email,
                    Password = password,
                };

                var loginToken = await _httpClient
                    .SendAsync<LoginResponse>(
                    $"{_apiOption.Host}{ApiType.login}",
                    HttpMethod.Post,
                    login);

                if (loginToken != null)
                {
                    _logger.LogInformation($"Acount {login.Email} succesfull login ");
                }
                else
                {
                    _logger.LogError("Missing email or password");
                }

                return new Login()
                {
                    Token = loginToken!.Token!,
                };
            });
        }
    }
}
