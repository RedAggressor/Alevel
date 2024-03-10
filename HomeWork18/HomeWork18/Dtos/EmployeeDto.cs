using Newtonsoft.Json;

namespace HomeWork18.Dtos
{
    internal class EmployeeDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("job")]
        public string Job { get; set; } = null!;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}
