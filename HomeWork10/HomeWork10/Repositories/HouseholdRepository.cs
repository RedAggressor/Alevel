using HomeWork10.Entities;
using HomeWork10.Models.Enums;
using HomeWork10.Repositories.Abstructs;
using System.Drawing;

namespace HomeWork10.Repositories
{
    internal class HouseholdRepository : IHouseholdRepository
    {
        private readonly List<HouseholdEntity> _mockServer = new List<HouseholdEntity>();

        public string AddHousehold(string name, int consumes, int power, BrendEntity brend, Color color, TypeHousehold typeAppliance)
        {
            HouseholdEntity household = new HouseholdEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Consumes = consumes,
                Power = power,
                Brend = brend,
                Color = color,
                TypeHousehold = typeAppliance,
            };

            _mockServer.Add(household);

            return household.Id;
        }

        public HouseholdEntity GetAppliances(string id)
        {
            foreach (var item in _mockServer)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
