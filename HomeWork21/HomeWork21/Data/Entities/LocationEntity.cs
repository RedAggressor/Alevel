namespace HomeWork21.Data.Entities
{
    internal class LocationEntity
    {
        public int Id { get; set; }
        public string? LocationName { get; set; }

        public int PetId { get; set; }
        public PetEntity? Pet { get; set; }
    }
}
