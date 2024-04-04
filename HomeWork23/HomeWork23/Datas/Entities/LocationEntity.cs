namespace HomeWork23.Datas.Entities
{
    internal class LocationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<PetEntity> Pets { get; set; } = new List<PetEntity>();
    }
}
