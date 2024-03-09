namespace HomeWork18.Services.Abstracts
{
    internal interface IInternalHttpClientService
    {
        public Task SendAsync(string url, HttpMethod method, object? content = null);
        public Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null);

    }
}
