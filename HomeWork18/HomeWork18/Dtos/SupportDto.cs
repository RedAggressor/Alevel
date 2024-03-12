using Newtonsoft.Json;

namespace HomeWork18.Dtos
{
    internal class SupportDto
    {
        [JsonProperty(PropertyName = "url")]
        public string? Url { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string? Text { get; set; }
    }
}
