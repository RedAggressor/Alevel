namespace HomeWork23.Datas.Entities
{
    internal class BreedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public ICollection<PetEntity> Pets { get; set; } = new List<PetEntity>();
    }
}
