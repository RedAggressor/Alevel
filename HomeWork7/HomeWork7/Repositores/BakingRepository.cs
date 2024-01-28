using Entities;

namespace Repositores
{
    internal class BakingRepository : SweetsRepository
    {
        List<BakingEntity> _sweetsList = new List<BakingEntity>();

        public override string AddSweets(string name, int weight)
        {
            BakingEntity sweetsEntity = new BakingEntity()
            {
                Id = Guid.NewGuid().ToString(),

                Name = name,

                Weight = weight
            };

            _sweetsList.Add(sweetsEntity);

            return sweetsEntity.Id;
        }

        public override BakingEntity GetSweets(string id)
        {
            foreach (var item in _sweetsList)
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
