using Newtonsoft.Json;

namespace HomeWork18.Dtos
{
    internal class UserDto
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string? LastName { get; set; }

        public string? Avatar { get; set; }
    }
}
