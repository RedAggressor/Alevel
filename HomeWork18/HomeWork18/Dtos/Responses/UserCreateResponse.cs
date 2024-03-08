using Newtonsoft.Json;

namespace HomeWork18.Dtos.Responses
{
    internal class UserCreateResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTimeOffset CreateAt { get; set; }
    }
}
