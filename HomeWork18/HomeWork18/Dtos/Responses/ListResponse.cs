using Newtonsoft.Json;

namespace HomeWork18.Dtos.Responses
{
    internal class ListResponse<T> : PageDto
        where T : class
    {
        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }

        public SupportDto Support { get; set; }

    }
}
