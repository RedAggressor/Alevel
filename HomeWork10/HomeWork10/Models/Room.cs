namespace HomeWork10.Models
{
    internal class Room
    {
        public string Id { get; set; }
        public List<ElectricalAppliances> Appliances { get; set; } = new List<ElectricalAppliances>();
    }
}
