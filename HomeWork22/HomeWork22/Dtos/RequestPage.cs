using Microsoft.Identity.Client;

namespace HomeWork22.Dtos
{
    internal class RequestPage : PageDto
    {
        public string? Name { get; set; } = string.Empty;
        public double PriceMax { get; set; } = 0;
        public double PriceMin { get; set;} = 0;

    }
}
