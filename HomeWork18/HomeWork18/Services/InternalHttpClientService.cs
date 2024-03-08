using HomeWork18.Services.Abstracts;
using Newtonsoft.Json;
using System.Text;

namespace HomeWork18.Services
{
    internal class InternalHttpClientService : IInternalHttpClientService
    {
        private readonly IHttpClientFactory? _clientFactory;

        public InternalHttpClientService(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public async Task<TResponse> SendAsync<TResponse, TRequest>(
            string url,
            HttpMethod httpMethod,
            TRequest? content = null)
            where TRequest : class
        {
            var client = _clientFactory.CreateClient();
            
            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = httpMethod;

            if (content != null)
            {
                httpMessage.Content = new StringContent(
                        JsonConvert.SerializeObject(content),
                        Encoding.UTF8,
                        "application/json");
            }

            var result = await client.SendAsync(httpMessage);

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                return response!;
            }

            return default(TResponse) !;
        }
    }
}
