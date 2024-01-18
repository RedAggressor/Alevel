using Services.Abstraction;
using Models;
using Repositores.Abstraction;
using Entities;

namespace Services
{
    internal class ChocolateService : SweetsService
    {
        private ISweetsRepository _repository;

        private ILoggerService _logger;

        private INotifyService _notify;

        public ChocolateService(ISweetsRepository chocolateRepository, ILoggerService loggerService, INotifyService notifyService) : base(chocolateRepository, loggerService, notifyService)
        {
            _repository = chocolateRepository;

            _logger = loggerService;

            _notify = notifyService;
        }

        public override string AddSweets(string name, int weight)
        {
            string id = _repository.AddSweets(name, weight);

            string fullInfo = GetFullInfo(id);

            string logMessage = $"Chocolate was create: {fullInfo}";

            //string notifyMessage = "Create was seccusfull";

            //string notifyToSend = "Console, if need change to mailAdress";

            //_notifyService.Notify(Notify.Console, notifyMessage, notifyToSend);

            _logger.Log(LogType.Info, logMessage);

            return id;
        }

        public override Chocolate GetSweets(string id)
        {
            ChocolateEntity sweetsService = (ChocolateEntity)_repository.GetSweets(id);

            string messageLog = "Sweets not founded";

            if (sweetsService == null)
            {
                _logger.Log(LogType.Error, messageLog);
            }

            return new Chocolate()
            {
                Id = sweetsService.Id,

                Name = sweetsService.Name,

                Weight = sweetsService.Weight
            };
        }
    }
}
