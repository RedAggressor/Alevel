namespace HomeWork21.Models
{
    internal class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Category? Category { get; set; }
        public Breed? Breed { get; set; }
        public float Age { get; set; }
        public Location? Location { get; set; }
        public string? ImageUrl { get; set; }
        public string? Discription { get; set; }

    }
}
