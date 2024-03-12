using Newtonsoft.Json;

namespace HomeWork18.Dtos
{
    internal class PageDto
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "per_page")]
        public int CountUsersForPage { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int TotalUsers { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TatalPages { get; set; }
    }
}
