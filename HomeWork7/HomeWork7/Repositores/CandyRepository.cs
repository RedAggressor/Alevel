using Entities;

namespace Repositores
{
    internal class CandyRepository : ChocolateRepository
    {
        List<CandyEntity> _sweetsList = new List<CandyEntity>();

        public override string AddSweets(string name, int weight)
        {
            CandyEntity sweetsEntity = new CandyEntity()
            {
                Id = Guid.NewGuid().ToString(),

                Name = name,

                Weight = weight
            };

            _sweetsList.Add(sweetsEntity);

            return sweetsEntity.Id;
        }

        public override CandyEntity GetSweets(string id)
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
