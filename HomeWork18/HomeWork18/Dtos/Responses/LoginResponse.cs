using Newtonsoft.Json;

namespace HomeWork18.Dtos.Responses
{
    internal class LoginResponse : ErrorTextDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string? Token { get; set; }
    }
}
