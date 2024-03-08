using Newtonsoft.Json;

namespace HomeWork18.Dtos.Responses
{
    internal class UpdateUserResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
