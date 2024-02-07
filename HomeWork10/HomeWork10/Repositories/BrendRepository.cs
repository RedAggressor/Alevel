using HomeWork10.Entities;
using HomeWork10.Repositories.Abstructs;

namespace HomeWork10.Repositories
{
    internal class BrendRepository : IBrendRepository
    {
        public BrendEntity GetBrend()
        {
            return new BrendEntity()
            {
                Name = "Colosok",
                Country = "Ukraine",
                BrandRegistration = "Italy"
            };
        }
    }
}
