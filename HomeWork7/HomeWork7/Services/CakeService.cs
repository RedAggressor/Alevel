using Entities;
using Services.Abstraction;
using Models;
using Repositores.Abstraction;


namespace Services
{
    internal class CakeService : BakingService
    {
        private ISweetsRepository _repository;

        private ILoggerService _logger;

        private INotifyService _notify;

        public CakeService(ISweetsRepository cakeRepository, ILoggerService loggerService, INotifyService notifyService) : base(cakeRepository, loggerService, notifyService)
        {
            _repository = cakeRepository;

            _logger = loggerService;

            _notify = notifyService;
        }

        public override string AddSweets(string name, int weight)
        {
            string id = _repository.AddSweets(name, weight);

            string fullInfo = GetFullInfo(id);

            string logMessage = $"Cake was create: {fullInfo}";

            //string notifyMessage = "Create was seccusfull";

            //string notifyToSend = "Console, if need change to mailAdress";

            //_notifier.Notify(Notify.Console, notifyMessage, notifyToSend);

            _logger.Log(LogType.Info, logMessage);

            return id;
        }

        public override Cake GetSweets(string id)
        {
            CakeEntity sweetsEntity = (CakeEntity)_repository.GetSweets(id);

            string messageLog = "Sweets not founded";

            if (sweetsEntity == null)
            {
                _logger.Log(LogType.Error, messageLog);

                return null;
            }

            return new Cake()
            {
                Id = sweetsEntity.Id,

                Name = sweetsEntity.Name,

                Weight = sweetsEntity.Weight
            };
        }
    }
}
