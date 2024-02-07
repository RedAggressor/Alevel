﻿using HomeWork10.Models.Enums;

namespace HomeWork10.Entities
{
    internal class InstrumentsEntity : ElectricalAplianceEntity
    {
        public int Weight { get; set; }
        public InstrumentsType InstrumentsType { get; set; }
    }
}
