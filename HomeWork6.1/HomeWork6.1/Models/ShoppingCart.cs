using Entites;

namespace Models
{
    internal class ShoppingCart
    {
        public string Id { get; set; }

        public List<Item> ListItem { get; set; }

        public int TotalSum { get; set; }
    }
}
