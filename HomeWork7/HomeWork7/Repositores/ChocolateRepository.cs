using Entities;

namespace Repositores
{
    internal class ChocolateRepository : SweetsRepository
    {
        List<ChocolateEntity> _sweetsList = new List<ChocolateEntity>();
        public override string AddSweets(string name, int weight)
        {
            ChocolateEntity sweetsEntity = new ChocolateEntity()
            {
                Id = Guid.NewGuid().ToString(),

                Name = name,

                Weight = weight
            };

            _sweetsList.Add(sweetsEntity);

            return sweetsEntity.Id;
        }

        public override ChocolateEntity GetSweets(string id)
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
