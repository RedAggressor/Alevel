namespace HomeWork21.Data.Entities
{
    internal class LocationEntity
    {
        public int Id { get; set; }
        public string LocationName { get; set; } = null!;

        public ICollection<PetEntity> Pet { get; set; } = new List<PetEntity>();
    }
}
