using HomeWork10.Models;

namespace HomeWork10.Services.Abstractions
{
    internal interface IRoomService
    {
        public void SwitchApliances(ElectricalAppliances electrical);
        public Room GetRoom();
        public void ShowInfoAboutApliance();
    }
}
