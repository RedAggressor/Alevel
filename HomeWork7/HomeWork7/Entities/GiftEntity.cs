using Models;

namespace Entities
{
    internal class GiftEntity
    {
        public string Id { get; set; }

        public int Weight { get; set; }

        public List<Sweets> SweetsList {get;set;}
    }
}
