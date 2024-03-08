using Newtonsoft.Json;

namespace HomeWork18.Dtos.Responses
{
    internal class SingleResponse<T>
        where T : class
    {
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        [JsonProperty(PropertyName = "support")]
        public SupportDto Support { get; set; }
    }
}
