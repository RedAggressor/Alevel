using HomeWork18.Dtos;
using HomeWork18.Helpers;
using HomeWork18.Services.Abstracts;
using Newtonsoft.Json;
using System.Text;

namespace HomeWork18.Services
{
    internal class InternalHttpClientService : IInternalHttpClientService
    {
        private readonly IHttpClientFactory? _httpClient;

        public InternalHttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task SendAsync(string url, HttpMethod method, object? content = null)
        {
            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = method;

            if (content != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage result;

            try
            {
                var httpClient = _httpClient.CreateClient();
                result = await httpClient.SendAsync(httpMessage);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }

            throw new BusinessException(null!, result.StatusCode.ToString());
        }

        public async Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null)
        {
            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = method;

            if (content != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage result;

            try
            {
                var httpClient = _httpClient.CreateClient();
                result = await httpClient.SendAsync(httpMessage);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }

            var resultContent = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);

                if (response is ErrorTextDto error && !string.IsNullOrEmpty(error.ErrorBody))
                {
                    throw new BusinessException(error.ErrorBody, ErrorCodes.Validation);
                }

                return response!;
            }

            throw new BusinessException(resultContent, result.StatusCode.ToString());
        }
    }
}
