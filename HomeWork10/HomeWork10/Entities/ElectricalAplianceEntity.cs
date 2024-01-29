namespace HomeWork10.Entities
{
    internal class ElectricalAplianceEntity : AplianceEntity
    {
        
        public int Consumes { get; set; }
        public int Power { get; set; }
        public BrendEntity Brend { get; set; }
    }
}
