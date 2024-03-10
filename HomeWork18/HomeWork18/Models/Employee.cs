namespace HomeWork18.Models
{
    internal class Employee : Validation
    {
        public string Name { get; set; } = null!;

        public string Job { get; set; } = null!;

        public int Id { get; set; }

        public string? CreatedAt { get; set; }

        public string? UpdatedAt { get; set; }
    }
}
