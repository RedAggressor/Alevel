using Entities;

namespace Repositoreis.Abstract
{
    internal interface IVegetablesRepository
    {
        public string AddVegetables(string name, double weight, double calories);
        public VegetablesEntity? GetVegetables(string id);
    }
}
