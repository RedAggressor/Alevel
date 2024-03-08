using Newtonsoft.Json;

namespace HomeWork18.Dtos.Responses
{
    internal class LoginResponse
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
