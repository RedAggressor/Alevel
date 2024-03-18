namespace HomeWork21.Data.Entities
{
    internal class BreedEntity
    {
        public int Id { get; set; }
        public string BreedName { get; set; } = null!;
        public int PetId { get; set; }
        public PetEntity Pet { get; set; } = null!;

        public List<CategoryEntity> Category { get; set; } = new List<CategoryEntity>();
    }
}
