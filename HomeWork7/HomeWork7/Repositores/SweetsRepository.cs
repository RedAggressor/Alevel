using Entities;
using Repositores.Abstraction;

namespace Repositores
{
    internal class SweetsRepository : ISweetsRepository
    {
        List<SweetsEntity> _sweetsList = new List<SweetsEntity>();

        public virtual string AddSweets(string name, int weight)
        {
            SweetsEntity sweetsEntity = new SweetsEntity()
            {
                Id = Guid.NewGuid().ToString(),

                Name = name,

                Weight = weight
            };

            _sweetsList.Add(sweetsEntity);

            return sweetsEntity.Id;
        }

        public virtual SweetsEntity GetSweets(string id)
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
