using HomeWork10.Models.Enums;
using System.Drawing;

namespace HomeWork10.Models
{
    internal class Household : ElectricalAppliances
    {
        public Color Color { get; set; }
        public TypeHousehold TypeHousehold { get; set; }
    }
}
