using HomeWork10.Models;

namespace HomeWork10.Services.Abstractions
{
    internal interface IRosetteService
    {
        public ElectricalAppliances СonnecDisconectDevice(ElectricalAppliances electricalAppliances, bool jumper = false);
        
    }
}
