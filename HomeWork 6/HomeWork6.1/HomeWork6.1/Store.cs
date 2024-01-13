using Service;
using System.Text;

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
            List<string> listItem = CreateListItemId();

            Console.WriteLine(GetBill(listItem));

            int totalSumBill = GetTotalPrice(listItem);

            Console.WriteLine($"Total Price {totalSumBill}");
        }
        public List<string> CreateListItemId()
        {
            int countItem = new Random().Next(5, 11);

            List<string> listItemId = new List<string>();

            for (int i = 0; i < countItem; i++)
            {
                listItemId.Add(_itemService.AddItem(GetNameItem(), GetAmountItem(), GetPriceItem()));
            }
            return listItemId;
        }
        public int GetTotalPrice(List<string> ListBuys)
        {
            int sum = 0;

            foreach (var item in ListBuys)
            {
                sum += _itemService.GetItem(item).Price;
            }

            return sum;
        }
        public string GetBill(List<string> ListBuys)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in ListBuys)
            {
                _itemService.GetItem(item);

                stringBuilder.Append($"{_itemService.GetInfoItem(item)}\n");
            }
            return stringBuilder.ToString();
        }
        public string GetNameItem() => _itemsName[new Random().Next(0, _itemsName.Length)];

        public static int GetAmountItem() => new Random().Next(1, 51);

        public static int GetPriceItem() => new Random().Next(10, 201);
 
    }
}
