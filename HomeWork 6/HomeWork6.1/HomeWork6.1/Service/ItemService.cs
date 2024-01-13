using Repository;
using Models;
using Entites;

namespace Service
{
    internal class ItemService
    {
        private readonly ItemRepository _repository;

        private readonly LoggerService _loggerService;

        private readonly NotificationService _notificationService;

        public ItemService(ItemRepository itemRepository, LoggerService loggerService, NotificationService notificationService)
        { 
            _repository = itemRepository;

            _loggerService = loggerService;

            _notificationService = notificationService;
        }

        public string AddItem(string name, int amount, int price)
        {
            string id = _repository.AddItem(name, amount, price);

            string messageLog = $"Create Item with id {id}: {name}: {amount}: {price}";

            string messageNotify = $"Item successful add";

            _loggerService.log(LogType.Info, messageLog);

            _notificationService.Notify(messageNotify);

            return id;
        }

        public string GetInfoItem(string id)
        {
            GetItem(id);

            return $"{GetItem(id).Id}: {GetItem(id).Name}: {GetItem(id).Amount}: {GetItem(id).Price}";
        }

        public Item GetItem(string id)
        {
            ItemEntity item = _repository.GetItem(id);

            if (item == null)
            {
                string messageLog = $"Not founded item with id{id}";

                _loggerService.log(LogType.Error,messageLog);
            }

            return new Item()
            { 
                 Id = item.Id,

                 Name = item.Name,

                 Amount = item.Amount,

                 Price = item.Price
            };
        }


    }
}
