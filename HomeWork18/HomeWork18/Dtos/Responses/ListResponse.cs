using Newtonsoft.Json;

namespace HomeWork18.Dtos.Responses
{
    internal class ListResponse<T>
        where T : class
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "per_page")]
        public int CountUsersForPage { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int TotalUsers { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TatalPage { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<T>? ListDto { get; set; }

        [JsonProperty(PropertyName = "support")]
        public SupportDto Support { get; set; }

    }
}
