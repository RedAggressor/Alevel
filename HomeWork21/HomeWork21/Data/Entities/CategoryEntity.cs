namespace HomeWork21.Data.Entities
{
    internal class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public int PetId { get; set; }
        public PetEntity? Pet { get; set; }

        public int BreedId { get; set; }
        public BreedEntity? Breed { get; set; }
    }
}
