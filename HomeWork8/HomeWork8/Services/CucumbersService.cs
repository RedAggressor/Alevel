using Entities;
using Models;
using Repositoreis.Abstract;
using Services.Abstract;

namespace Services
{
    internal class CucumbersService : VegetableService
    {
        private IVegetablesRepository _repository;
        private ILoggerService _logger;
        private INotifyService _notify;

        public CucumbersService(IVegetablesRepository vegetablesRepository, ILoggerService loggerService, INotifyService notifyService) : base(vegetablesRepository, loggerService, notifyService)
        {
            _repository = vegetablesRepository;
            _logger = loggerService;
            _notify = notifyService;
        }

        public override string AddVegetable(double weight)
        {
            string name = "Cucumber";

            double calories = 0.11;

            string id = _repository.AddVegetables(name, weight, calories);

            string messageLog = $"Create {name} was succesfull id {id}";

            string toSend = "adress Console";

            string messageNotify = "Message send to";

            _logger.Log(TypeLog.Info, messageLog);

            _notify.Notify(TypeNoti.Console, messageNotify, toSend);

            return id;
        }

        public virtual Cucumbers GetVegetables(string id)
        {
            CucumbersEntity? vegetables = (CucumbersEntity?)_repository.GetVegetables(id);

            return new Cucumbers()
            {
                Id = id,
                Name = vegetables.Name,
                Weight = vegetables.Weight,
                Calories = vegetables.Calories
            };
        }
    }
}
