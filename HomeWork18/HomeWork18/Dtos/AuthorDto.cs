using Newtonsoft.Json;

namespace HomeWork18.Dtos
{
    internal class AuthorDto
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
