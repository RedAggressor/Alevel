using Entities;
using Models;
using Repositores.Abstraction;
using Services.Abstraction;

namespace Services
{
    internal class BakingService : SweetsService
    {
        private ISweetsRepository _repository;

        private ILoggerService _logger;

        private INotifyService _notifier;

        public BakingService(ISweetsRepository bakingRepository, ILoggerService loggerService, INotifyService notifyService) : base(bakingRepository, loggerService, notifyService)
        {
            _repository = bakingRepository;

            _logger = loggerService;

            _notifier = notifyService;
        }

        public override string AddSweets(string name, int weight)
        {
            string id = _repository.AddSweets(name, weight);

            string fullInfo = GetFullInfo(id);

            string logMessage = $"Baking was create: {fullInfo}";

            //string notifyMessage = "Create was seccusfull";

            //string notifyToSend = "Console, if need change to mailAdress";

            //_notifier.Notify(Notify.Console, notifyMessage, notifyToSend);

            _logger.Log(LogType.Info, logMessage);

            return id;
        }

        public override Baking GetSweets(string id)
        {
            BakingEntity sweetsService = (BakingEntity)_repository.GetSweets(id);

            if (sweetsService == null)
            {
               _logger.Log(LogType.Warning, "add loger, error Sweets not founded");
            }

            return new Baking()
            {
                Id = sweetsService.Id,

                Name = sweetsService.Name,

                Weight = sweetsService.Weight
            };
        }
    }
}
