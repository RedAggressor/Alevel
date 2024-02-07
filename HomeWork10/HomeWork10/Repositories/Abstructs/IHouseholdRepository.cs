using HomeWork10.Entities;

namespace HomeWork10.Repositories.Abstructs
{
    internal interface IHouseholdRepository
    {
        public string AddHousehold(HouseholdEntity householdEntity);
        public HouseholdEntity GetAppliances(string id);
    }
}
