using Entities;

namespace Repositoreis
{
    internal class TomatoesRepository : FruityRepository
    {
        private List<TomatoesEntity> _vegetablesList = new List<TomatoesEntity>();

        public override string AddVegetables(string name, double weight, double calories)
        {
            TomatoesEntity vegetables = new TomatoesEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Weight = weight,
                Calories = calories * weight
            };

            _vegetablesList.Add(vegetables);

            return vegetables.Id;
        }

        public override TomatoesEntity? GetVegetables(string id)
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
