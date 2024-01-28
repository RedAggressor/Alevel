using Entities;

namespace Repositoreis
{
    internal class CucumbersRepository : FruityRepository
    {
        private List<CucumbersEntity> _vegetablesList = new List<CucumbersEntity>();

        public override string AddVegetables(string name, double weight, double calories)
        {
            CucumbersEntity vegetables = new CucumbersEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Weight = weight,
                Calories = calories * weight
            };

            _vegetablesList.Add(vegetables);

            return vegetables.Id;
        }

        public override CucumbersEntity? GetVegetables(string id)
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
