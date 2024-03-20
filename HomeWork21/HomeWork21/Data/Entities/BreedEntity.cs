namespace HomeWork21.Data.Entities
{
    internal class BreedEntity
    {
        public int Id { get; set; }
        public string BreedName { get; set; } = null!;
        public ICollection<PetEntity> Pet { get; set; } = new List<PetEntity>();

        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
