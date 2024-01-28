using Models;

namespace Entities
{
    internal class SaladBowlEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public List<Vegetables> VegetablesList { get; set; }
    }
}
