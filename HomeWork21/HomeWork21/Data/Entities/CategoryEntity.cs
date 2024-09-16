namespace HomeWork21.Data.Entities
{
    internal class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
               
        public ICollection<PetEntity> Pet { get; set; } = new List<PetEntity>();
        public ICollection<BreedEntity> Breed { get; set; } = new List<BreedEntity>();
    }
}
