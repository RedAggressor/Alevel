using Entities;
using Models;

namespace Repositoreis.Abstract
{
    internal interface ISaladBowlReposotory
    {
        public string AddCaladBowl(double weight, string name, List<Vegetables> vegetablesList);
        public SaladBowlEntity GetSaladBowl(string id);
        
    }
}
