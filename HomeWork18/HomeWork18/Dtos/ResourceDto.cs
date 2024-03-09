using Newtonsoft.Json;

namespace HomeWork18.Dtos
{
    internal class ResourceDto
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? ColorName { get; set; }

        public int Year { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string? ColorCode { get; set; }

        [JsonProperty(PropertyName = "pantone_value")]
        public string? PantoneValue { get; set; }
    }
}
