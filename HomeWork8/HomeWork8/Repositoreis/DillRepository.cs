using Entities;

namespace Repositoreis
{
    internal class DillRepository : VegetativeRepository
    {
        private List<DillEntity> _vegetablesList = new List<DillEntity>();

        public override string AddVegetables(string name, double weight, double calories)
        {
            DillEntity vegetables = new DillEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Weight = weight,
                Calories = calories * weight
            };

            _vegetablesList.Add(vegetables);

            return vegetables.Id;
        }

        public override DillEntity? GetVegetables(string id)
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
