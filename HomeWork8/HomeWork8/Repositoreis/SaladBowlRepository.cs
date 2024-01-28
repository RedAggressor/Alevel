using Entities;
using Models;
using Repositoreis.Abstract;

namespace Repositoreis
{
    internal class SaladBowlRepository : ISaladBowlReposotory
    {
        private List<SaladBowlEntity> _mockListSalatBowl = new List<SaladBowlEntity>();

        public string AddCaladBowl(double weight, string name, List<Vegetables> vegetablesList)
        {
            SaladBowlEntity saladBowl = new SaladBowlEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Weight = weight,
                VegetablesList = vegetablesList
            };

            _mockListSalatBowl.Add(saladBowl);

            return saladBowl.Id;
        }

        public SaladBowlEntity GetSaladBowl(string id)
        {
            foreach (var item in _mockListSalatBowl)
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
