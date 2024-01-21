using Entities;

namespace Repositoreis
{
    internal class OnionRepository : VegetativeRepository
    {
        private List<OnionEntity> _vegetablesList = new List<OnionEntity>();

        public override string AddVegetables(string name, double weight, double calories)
        {
            OnionEntity vegetables = new OnionEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Weight = weight,
                Calories = calories * weight
            };

            _vegetablesList.Add(vegetables);

            return vegetables.Id;
        }

        public override OnionEntity? GetVegetables(string id)
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
