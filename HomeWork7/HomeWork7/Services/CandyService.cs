using Entities;
using Services.Abstraction;
using Models;
using Repositores.Abstraction;


namespace Services
{
    internal class CandyService : ChocolateService
    {
        private ISweetsRepository _repository;

        private ILoggerService _logger;

        private INotifyService _notify;

        public CandyService(ISweetsRepository candyRepository, ILoggerService loggerService, INotifyService notifyService) : base(candyRepository, loggerService, notifyService)
        {
            _repository = candyRepository;

            _logger = loggerService;

            _notify = notifyService;
        }

        public override string AddSweets(string name, int weight)
        {
            string id = _repository.AddSweets(name, weight);

            string fullInfo = GetFullInfo(id);

            string logMessage = $"Candy was create: {fullInfo}";

            //string notifyMessage = "Create was seccusfull";

            //string notifyToSend = "Console, if need change to mailAdress";

            //_notify.Notify(Notify.Console, notifyMessage, notifyToSend);

            _logger.Log(LogType.Info, logMessage);

            return id;
        }

        public override Candy GetSweets(string id)
        {
            CandyEntity sweetsEntity = (CandyEntity)_repository.GetSweets(id);

            string messageLog = "Sweets not founded";

            if (sweetsEntity == null)
            {
                _logger.Log(LogType.Error, messageLog);

                return null;
            }

            return new Candy()
            {
                Id = sweetsEntity.Id,

                Name = sweetsEntity.Name,

                Weight = sweetsEntity.Weight
            };
        }
    }
}
