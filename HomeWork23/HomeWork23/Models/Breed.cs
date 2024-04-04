namespace HomeWork23.Models
{
    internal class Breed
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
