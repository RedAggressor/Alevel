using Newtonsoft.Json;

namespace HomeWork18.Dtos
{
    internal class ErrorTextDto
    {
        [JsonProperty("error")]
        public string? ErrorBody { get; set; }
    }
}
