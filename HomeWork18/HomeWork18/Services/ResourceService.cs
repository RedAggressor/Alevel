using HomeWork18.Config;
using HomeWork18.Dtos.Responses;
using HomeWork18.Dtos;
using HomeWork18.Services.Abstracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HomeWork18.Models;
using HomeWork18.Enums;

namespace HomeWork18.Services
{
    internal class ResourceService : BaseService, IResourseService
    {
        private readonly IInternalHttpClientService _httpClient;
        private readonly ApiOption _apiOption;
        private readonly ILogger<ResourceService> _logger;

        public ResourceService(
            IInternalHttpClientService internalHttpClientService,
            IOptions<ApiOption> options,
            ILogger<ResourceService> logger)
        {
            _httpClient = internalHttpClientService;
            _apiOption = options.Value;
            _logger = logger;
        }

        public async Task<ListData<Resource>> GetListResourcesAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _httpClient
                .SendAsync<ListResponse<ResourceDto>>(
                    $"{_apiOption.Host}/{ApiType.unknown}",
                    HttpMethod.Get);

                if (result != null)
                {
                    _logger.LogInformation($"Source was found");

                    return new ListData<Resource>()
                    {
                        Data = result!.Data.Select(s => new Resource
                        {
                            ColorCode = s.ColorCode,
                            ColorName = s.ColorName,
                            Id = s.Id,
                            PantoneValue = s.PantoneValue,
                            Year = s.Year,
                        }).ToList(),
                    };
                }

                return null!;
            });
        }

        public async Task<Resource> GetResourceAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _httpClient
                .SendAsync<SingleResponse<ResourceDto>>(
                    $"{_apiOption.Host}/{ApiType.unknown}/{id}",
                    HttpMethod.Get);

                if (result!.Data != null)
                {
                    _logger.LogInformation($"Source with id = {result.Data.Id} was found");

                    return new Resource()
                    {
                        Id = result.Data.Id,
                        ColorCode = result.Data.ColorCode,
                        ColorName = result.Data.ColorName,
                        PantoneValue = result.Data.PantoneValue,
                        Year = result.Data.Year,
                    };
                }

                return null!;
            });
        }
    }
}
