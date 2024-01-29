using HomeWork10.Entities;
using HomeWork10.Models.Enums;
using System.Drawing;

namespace HomeWork10.Repositories.Abstructs
{
    internal interface IHouseholdRepository
    {
        public string AddHousehold(string name, int consumes, int power, BrendEntity brend, Color color, TypeHousehold typeAppliance);
        public HouseholdEntity GetAppliances(string id);
    }
}
