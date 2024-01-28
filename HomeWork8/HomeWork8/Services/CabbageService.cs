using Entities;
using Models;
using Repositoreis.Abstract;
using Services.Abstract;

namespace Services
{
    internal class CabbageService : VegetableService
    {
        private IVegetablesRepository _repository;
        private ILoggerService _logger;
        private INotifyService _notify;

        public CabbageService(IVegetablesRepository vegetablesRepository, ILoggerService loggerService, INotifyService notifyService) : base(vegetablesRepository, loggerService, notifyService)
        {
            _repository = vegetablesRepository;
            _logger = loggerService;
            _notify = notifyService;
        }

        public override string AddVegetable(double weight)
        {
            string name = "Cabbage";

            double calories = 0.24;

            string id = _repository.AddVegetables(name, weight, calories);

            string messageLog = $"Create {name} was succesfull id {id}";

            string toSend = "adress Console";

            string messageNotify = "Message send to";

            _logger.Log(TypeLog.Info, messageLog);

            _notify.Notify(TypeNoti.Console, messageNotify, toSend);

            return id;
        }

        public override Cabbage GetVegetables(string id)
        {
            CabbageEntity? vegetables = (CabbageEntity?)_repository.GetVegetables(id);

            return new Cabbage()
            {
                Id = id,
                Name = vegetables.Name,
                Weight = vegetables.Weight,
                Calories = vegetables.Calories
            };
        }

    }
}
