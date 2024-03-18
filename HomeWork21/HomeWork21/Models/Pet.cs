namespace HomeWork21.Models
{
    internal class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Category> Category { get; set; } = null!;
        public IEnumerable<Breed> Breed { get; set; } = null!;
        public float Age { get; set; }
        public IEnumerable<Location> Location { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Discription { get; set; }

    }
}
