using Entities;
using Models;
using Repositores.Abstraction;

namespace Repositores
{
    internal class GiftRepository : IGiftRepository
    {
        public List<GiftEntity> _giftEntities = new List<GiftEntity>();

        public string AddGift(int weight)
        {
            GiftEntity giftEntity = new GiftEntity()
            {
                Id = Guid.NewGuid().ToString(),

                Weight = weight,

                SweetsList = new List<Sweets>()
            };

            _giftEntities.Add(giftEntity);

            return giftEntity.Id;
        }

        public GiftEntity GetGift(string id)
        {
            foreach (var item in _giftEntities)
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
