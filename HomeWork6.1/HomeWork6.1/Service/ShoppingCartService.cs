using Entites;
using Models;
using Repository;

namespace Service
{
    internal class ShoppingCartService
    {
        private readonly ShoppingCartRepository _repository;

        private readonly LoggerService _logger;

        private readonly NotificationService _notify;

        public ShoppingCartService(ShoppingCartRepository shoppingCartRepository, LoggerService loggerService, NotificationService notificationService)
        {
            _repository = shoppingCartRepository;

            _logger = loggerService;

            _notify = notificationService;
        }

        public string AddOrder(List<Item> listItem)
        {
            string id = _repository.AddCart(listItem);

            int totalSumForOrder = TotalSumForOrder(listItem);

            string messageLog = $"Create new order id: {id}, for TotalSum = {totalSumForOrder}";

            string messageNotify = $"Order was created total sum: {totalSumForOrder}";

            _logger.log(LogType.Info, messageLog);

            _notify.Notify(NotifyType.Console, messageNotify);

            return id;
        }

        public ShoppingCart GetOder(string id)
        {
            ShoppingCartEntity? shoppingCartEntity = _repository.GetCart(id);

            if(shoppingCartEntity == null) 
            {
                string messageLog = $"Not founded order with id{id}";

                _logger.log(LogType.Error, messageLog);
            }

            return new ShoppingCart()
            {
                Id = shoppingCartEntity.Id,

                ListItem = shoppingCartEntity.ListItem,
            };
        }

        public void ShowFullInfoOrder(string id)
        {
            ShoppingCartEntity? shoppingCartEntity = _repository.GetCart(id);

            List<Item> listItem = shoppingCartEntity?.ListItem;

            string messageLog = "At first create order!!";

            int totalSum = TotalSumForOrder(listItem);

            if (listItem == null)
            {
                _logger.log(LogType.Error, messageLog);

                return;
            }

            foreach (var item in listItem)
            {
                Console.WriteLine($"Product name: {item.Name}, Count: { item.Amount}, Price: { item.Price} ");
            }

            Console.WriteLine();
        }

        private int TotalSumForOrder(List<Item> listorder)
        {
            return listorder.Select(p => p.Price).Sum();
        }
    }   
}