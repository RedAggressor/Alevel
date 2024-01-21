using Models;

namespace Services.Abstract
{
    internal interface IVegetablesService
    {
        public string AddVegetable(double weight);

        public Vegetables GetVegetables(string id);

    }
}
