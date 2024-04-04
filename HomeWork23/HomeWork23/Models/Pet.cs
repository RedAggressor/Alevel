namespace HomeWork23.Models
{
    internal class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int BreedId { get; set; }
        public Breed? Breed { get; set; }
        public int Age { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
