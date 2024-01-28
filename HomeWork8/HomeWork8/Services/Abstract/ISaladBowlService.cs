using Models;

namespace Services.Abstract
{
    internal interface ISaladBowlService
    {
        public string AddSalad(List<Vegetables> ingridiensList, string name);
        public SaladBowl GetSalad(string id);
    }
}
