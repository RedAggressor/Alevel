using Entities;
using Services.Abstraction;
using Models;
using Repositores.Abstraction;

namespace Services
{
    internal class GiftService : IGiftService
    {
        private IGiftRepository _repository;

        private ILoggerService _logger;

        private INotifyService _notify;

        public GiftService(IGiftRepository giftRepository,ILoggerService loggerService, INotifyService notifyService)
        { 
            _repository = giftRepository;

            _logger = loggerService;

            _notify = notifyService;
        }

        public string CreateGift(int weight)
        {
            string id = _repository.AddGift(weight);

            string messageLogger = $"Create Gifts with Max weight {weight}";

            //string notifyMessage = "Sended";

            //string toSendMessage = "to Console";
            
            //_notify.Notify(Notify.Console, notifyMessage, toSendMessage);

            _logger.Log(LogType.Info, messageLogger);

            return id;
        }

        public Gift GetGift(string id)
        {
            GiftEntity gift = _repository.GetGift(id);

            string messageLog = "Gift not founded";

            if (gift == null)
            {
                _logger.Log(LogType.Error, messageLog);

                return null;
            }

            return new Gift()
            {
               Id = gift.Id,

               MaxWeight = gift.Weight,

               ListSweets = gift.SweetsList
            };
        }

        public void AddToGift(string id, Sweets sweets)
        {
            GiftEntity gift = _repository.GetGift(id);

            int totalWeightAllSweetsIn = gift.SweetsList.Select(t => t.Weight).Sum();

            int weightAddSweets = sweets.Weight;

            int maxWeightGift = gift.Weight;

            if (CheckWeight(totalWeightAllSweetsIn, weightAddSweets, maxWeightGift))
            {

                _logger.Log(LogType.Error, $"not enough space. the gift weight limit has been exceeded" +
               $" {totalWeightAllSweetsIn}/{maxWeightGift}, you add sweets {sweets.Name} with weight {weightAddSweets}");

                return;
            }

            _logger.Log(LogType.Info, $"Add new {sweets.GetType().Name} to Gift {sweets.Name}");

            gift.SweetsList.Add(sweets);
        }

        private bool CheckWeight(int totalWeightAllSweetsIn, int weightAddSweets, int maxWeightGift)
        {    
            return maxWeightGift < (totalWeightAllSweetsIn + weightAddSweets);
        }

        public List<Sweets> GetListOfSweets(string id)
        { 
            GiftEntity gift = _repository.GetGift(id);

            return gift.SweetsList;
        }
    }
}
