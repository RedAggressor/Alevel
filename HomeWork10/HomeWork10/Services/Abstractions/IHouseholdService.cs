using HomeWork10.Models;

namespace HomeWork10.Services.Abstractions
{
    internal interface IHouseholdService
    {
        public string AddHousehold(Household household);
        public Household GetHouseholds(string id);
        
    }
}
