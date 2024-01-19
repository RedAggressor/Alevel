using Models;
using Repository;
using Service;

namespace HomeWork6._1
{
    internal class Store
    {
        private readonly ItemService _itemService;

        private readonly string[] _itemsName =
        {
            "Banana", "Apple", "Pineapple", "Mango",
            "Oranges", "Apricot", "Melon", "Pear",
            "Mandarin", "Coconut", "Grapes", "Dragon Fruit"
        };

        public Store(ItemService itemService) 
        { 
            _itemService = itemService;
        }

        public void Start()
        {
            List<Item> order = CreateOrder();

            ShoppingCartService shoppingCart = GetNewCart();

            string idOrder = shoppingCart.AddOrder(order);

            int Totalsum = shoppingCart.GetOder(idOrder).ListItem.Select(p=>p.Price).Sum();

            shoppingCart.ShowFullInfoOrder(idOrder);
        }

        private List<Item> CreateOrder()
        {
            int countItem = new Random().Next(5, 11);

            List<string> listId = new List<string>();

            List<Item> listItem = new List<Item>();

            for (int i = 0; i < countItem; i++)
            {
                listId.Add(_itemService.AddItem(GetNameItem(), GetAmountItem(), GetPriceItem()));
            }

            foreach (var id in listId)
            {
                listItem.Add(_itemService.GetItem(id));
            }
            return listItem;
        }

        private ShoppingCartService GetNewCart()
        {
            return new ShoppingCartService(new ShoppingCartRepository(), new LoggerService(), new NotificationService(new LoggerService()));
        }
               
        public string GetNameItem() => _itemsName[new Random().Next(0, _itemsName.Length)];

        public static int GetAmountItem() => new Random().Next(1, 51);

        public static int GetPriceItem() => new Random().Next(10, 201);
 
    }
}
