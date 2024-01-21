using Entites;
using Models;

namespace Repository
{
    internal class ShoppingCartRepository
    {
        List<ShoppingCartEntity> shoppingCartEntities = new List<ShoppingCartEntity>();

        public string AddCart(List<Item> listItem)
        {
            ShoppingCartEntity shoppingCartEntity = new ShoppingCartEntity()
            { 
                Id = Guid.NewGuid().ToString(),

                ListItem = listItem
            };

            shoppingCartEntities.Add(shoppingCartEntity);

            return shoppingCartEntity.Id;
        }

        public ShoppingCartEntity? GetCart(string id)
        {
            foreach (var item in shoppingCartEntities)
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
