using HomeWork10.Entities;
using HomeWork10.Repositories.Abstructs;

namespace HomeWork10.Repositories
{
    internal class HouseholdRepository : IHouseholdRepository
    {
        private readonly List<HouseholdEntity> _mockServer = new List<HouseholdEntity>();

        public string AddHousehold(HouseholdEntity householdEntity)
        {
            HouseholdEntity household = new HouseholdEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = householdEntity.Name,
                Consumes = householdEntity.Consumes,
                Power = householdEntity.Power,
                Brend = householdEntity.Brend,
                Color = householdEntity.Color,
                HouseholdType = householdEntity.HouseholdType,
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
