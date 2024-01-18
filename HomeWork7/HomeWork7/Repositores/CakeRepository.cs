using Entities;

namespace Repositores
{
    internal class CakeRepository : BakingRepository
    {
        List<CakeEntity> _sweetsList = new List<CakeEntity>();

        public override string AddSweets(string name, int weight)
        {
            CakeEntity sweetsEntity = new CakeEntity()
            {
                Id = Guid.NewGuid().ToString(),

                Name = name,

                Weight = weight
            };

            _sweetsList.Add(sweetsEntity);

            return sweetsEntity.Id;
        }

        public override CakeEntity GetSweets(string id)
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
