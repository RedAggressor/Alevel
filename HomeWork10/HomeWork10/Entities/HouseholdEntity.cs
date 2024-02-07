using HomeWork10.Models.Enums;
using System.Drawing;

namespace HomeWork10.Entities
{
    internal class HouseholdEntity : ElectricalAplianceEntity
    {
        public Color Color { get; set; }
        public HouseholdType HouseholdType { get; set; }
    }
}
