using HomeWork10.Models;
using HomeWork10.Models.Enums;
using System.Drawing;

namespace HomeWork10.Services.Abstractions
{
    internal interface IHouseholdService
    {
        public string AddHousehold(string name, int consumes, Color color, TypeHousehold typeAppliance);
        public Household GetHouseholds(string id);
        
    }
}
