namespace HomeWork21.Models
{
    internal class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public int BreedId { get; set; }
        public float Age { get; set; }
        public int LocationId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Discription { get; set; }

    }
}
