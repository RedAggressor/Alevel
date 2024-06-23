using IdentityModel.Client;
using Infrastructure.Exeptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace MVC.Services;

public class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpClientService(
        IHttpClientFactory clientFactory,
        IHttpContextAccessor httpContextAccessor)
    {
        _clientFactory = clientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content)
    {
        var client = _clientFactory.CreateClient();
        //var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        //if (!string.IsNullOrEmpty(token))
        //{
        //    client.SetBearerToken(token);
        //}

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
