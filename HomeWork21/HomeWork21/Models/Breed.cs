namespace HomeWork21.Models
{
    internal class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Category? Category { get; set; }
    }
}
