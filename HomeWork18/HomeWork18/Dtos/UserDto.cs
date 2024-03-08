using Newtonsoft.Json;

namespace HomeWork18.Dtos
{
    internal class UserDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string? FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string? LastName { get; set; }

        [JsonProperty(PropertyName = "avatar")]
        public string? AvatarFoto { get; set; }
    }
}
