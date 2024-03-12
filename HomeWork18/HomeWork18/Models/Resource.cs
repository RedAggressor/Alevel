namespace HomeWork18.Models
{
    internal class Resource : Validation
    {
        public int Id { get; set; }

        public string? ColorName { get; set; } = null!;

        public int Year { get; set; }

        public string? ColorCode { get; set; } = null!;

        public string? PantoneValue { get; set; } = null!;
    }
}
