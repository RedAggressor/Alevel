using Entities;

namespace Repositoreis
{
    internal class CabbageRepository : VegetativeRepository
    {
        private List<CabbageEntity> _vegetablesList = new List<CabbageEntity>();

        public override string AddVegetables(string name, double weight, double calories)
        {
            CabbageEntity vegetables = new CabbageEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Weight = weight,
                Calories = calories*weight
            };

            _vegetablesList.Add(vegetables);

            return vegetables.Id;
        }

        public override CabbageEntity? GetVegetables(string id)
        {
            foreach (var item in _vegetablesList)
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
