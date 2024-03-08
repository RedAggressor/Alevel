using Newtonsoft.Json;

namespace HomeWork18.Dtos.Requests
{
    internal class UserRequest
    {
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "job")]
        public string? Job { get; set; }
    }
}
