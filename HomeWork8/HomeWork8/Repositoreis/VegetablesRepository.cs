using Entities;
using Repositoreis.Abstract;

namespace Repositoreis
{
    internal class VegetablesRepository : IVegetablesRepository
    {
        private List<VegetablesEntity> _vegetablesList = new List<VegetablesEntity> ();

        public virtual string AddVegetables(string name, double weight, double calories)
        {
            VegetablesEntity vegetables = new VegetablesEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Weight = weight,
                Calories = calories * weight
            };

            _vegetablesList.Add(vegetables);

            return vegetables.Id;
        }

        public virtual VegetablesEntity? GetVegetables(string id)
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
