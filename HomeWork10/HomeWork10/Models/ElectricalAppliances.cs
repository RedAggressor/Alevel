namespace HomeWork10.Models
{
    internal class ElectricalAppliances : Appliances
    {
        public int Consumes { get; set; }
        public int Power { get; set; }
        public Brend Brend { get; set; }
        public bool TornOn { get; set; } = false;
    }
}
