using Infrastructure.Exeptions;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace MVC.Services;

public class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;

    public HttpClientService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content)
    {
        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;

        if (content != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        HttpResponseMessage result;

        try 
        {
            var client = _clientFactory.CreateClient();
            result = await client.SendAsync(httpMessage);
        }
        catch (Exception ex) 
        {
            throw new BusinessException(ex.Message);
        }

        string resultContent = string.Empty;

        if (result.IsSuccessStatusCode)
        {
            resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);

            if (response is null) 
            {
                throw new BusinessException("Something is going wrong!");
            }

            return response!;
        }

        throw new BusinessException(resultContent, result.StatusCode.ToString());
    }
}
