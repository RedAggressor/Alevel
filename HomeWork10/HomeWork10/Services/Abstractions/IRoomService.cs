using HomeWork10.Models;

namespace HomeWork10.Services.Abstractions
{
    internal interface IRoomService
    {
        public void TurnOnOffApliance(ElectricalAppliances electrical);
        public Room GetRoom();
        public void ShowFullInfo();
    }
}
