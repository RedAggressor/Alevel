using Entites;

namespace Repository
{
    internal class ItemRepository
    {
        private readonly List<ItemEntity> _mockItemStorage = new List<ItemEntity>();

        public string AddItem(string name, int amount, int price)
        {
            ItemEntity item = new ItemEntity()
            {
                Id = Guid.NewGuid().ToString(),

                Name = name,

                Amount = amount,

                Price = price
            };

            _mockItemStorage.Add(item);

            return item.Id;
        }

        public List<ItemEntity> GetLogItem()
        { 
            return _mockItemStorage;
        }

        public ItemEntity? GetItem(string id)
        {
            foreach (var item in _mockItemStorage)
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
