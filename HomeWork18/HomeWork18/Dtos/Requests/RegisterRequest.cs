using Newtonsoft.Json;

namespace HomeWork18.Dtos.Requests
{
    internal class RegisterRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
