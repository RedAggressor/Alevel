namespace HomeWork18.Services.Abstracts
{
    internal interface IInternalHttpClientService
    {
        public Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod httpMethod, TRequest? content = null)
            where TRequest : class;
    }
}
