using Entities;

namespace Repositoreis
{
    internal class CornRepository : FruityRepository
    {
        private List<CornEntity> _vegetablesList = new List<CornEntity>();

        public override string AddVegetables(string name, double weight, double calories)
        {
            CornEntity vegetables = new CornEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Weight = weight,
                Calories = calories * weight
            };

            _vegetablesList.Add(vegetables);

            return vegetables.Id;
        }

        public override CornEntity? GetVegetables(string id)
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
