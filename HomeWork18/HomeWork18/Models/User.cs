namespace HomeWork18.Models
{
    internal class User : Validation
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Avatar { get; set; }
    }
}
