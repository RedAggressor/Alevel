namespace HomeWork21.Data.Entities
{
    internal class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Age { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

        public List<CategoryEntity> Category { get; set; } = new List<CategoryEntity>();
        public List<BreedEntity> Breed { get; set; } = new List<BreedEntity>();
        public List<LocationEntity> LocationName { get; set; } = new List<LocationEntity>();
    }
}
