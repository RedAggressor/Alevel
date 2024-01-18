using Entities;
using Repositores.Abstraction;
using Models;
using Services.Abstraction;

namespace Services
{
    internal class SweetsService: ISweetsService
    {
        private ISweetsRepository _repository;

        private ILoggerService _logger;

        private INotifyService _notify;

        
        public SweetsService(ISweetsRepository sweetsRepository, ILoggerService loggerService, INotifyService notifyService)
        { 
            _repository = sweetsRepository;

            _logger = loggerService;

            _notify = notifyService;
        }

        public virtual string AddSweets(string name, int weight)
        {
            string id = _repository.AddSweets(name, weight);

            string fullInfo = GetFullInfo(id);

            string logMessage = $"Sweets was create: {fullInfo}";

            //string notifyMessage = "Create was seccusfull";

            //string notifyToSend = "Console, if need change to mailAdress";
            
            //_notify.Notify(Notify.Console, notifyMessage, notifyToSend);

            _logger.Log(LogType.Info, logMessage);

            return id;
        }

        public virtual Sweets GetSweets(string id)
        {
            SweetsEntity sweetsEntity = _repository.GetSweets(id);

            string messageLog = "Sweets not founded";

            if (sweetsEntity == null)
            {
                _logger.Log(LogType.Error, messageLog);

                return null;
            }

            return new Sweets()
            { 
                Id = sweetsEntity.Id,

                Name = sweetsEntity.Name,

                Weight = sweetsEntity.Weight
            };
        }

        public string GetFullInfo(string id)
        {
            string name = GetSweets(id).Name;

            int weight = GetSweets(id).Weight;

            string typeSweets = GetSweets(id).GetType().Name;

            return $"id: {id}, name: {name}, weight: {weight}, type: {typeSweets}";
        }
    }
}
