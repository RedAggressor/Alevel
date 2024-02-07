using HomeWork10.Models.Enums;

namespace HomeWork10.Models
{
    internal class Instruments : ElectricalAppliances
    {
        public int Weight { get; set; }
        public InstrumentsType InstrumentsType { get; set; }
    }
}
