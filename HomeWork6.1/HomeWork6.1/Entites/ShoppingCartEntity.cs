using Models;

namespace Entites
{
    internal class ShoppingCartEntity
    {
        public string Id { get; set; }

        public List<Item> ListItem { get; set; }
    }
}
