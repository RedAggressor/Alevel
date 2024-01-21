using Entities;
using Models;
using Repositoreis.Abstract;
using Services.Abstract;

namespace Services
{
    internal class DillService : VegetableService
    {
        private IVegetablesRepository _repository;
        private ILoggerService _logger;
        private INotifyService _notify;

        public DillService(IVegetablesRepository vegetablesRepository, ILoggerService loggerService, INotifyService notifyService) : base(vegetablesRepository, loggerService, notifyService)
        {
            _repository = vegetablesRepository;
            _logger = loggerService;
            _notify = notifyService;
        }

        public override string AddVegetable(double weight)
        {
            string name = "Dill";

            double calories = 0.15;

            string id = _repository.AddVegetables(name, weight, calories);

            string messageLog = $"Create {name} was succesfull id {id}";

            string toSend = "adress Console";

            string messageNotify = "Message send to";

            _logger.Log(TypeLog.Info, messageLog);

            _notify.Notify(TypeNoti.Console, messageNotify, toSend);

            return id;
        }

        public virtual Dill GetVegetables(string id)
        {
            DillEntity? vegetables = (DillEntity?)_repository.GetVegetables(id);

            return new Dill()
            {
                Id = id,
                Name = vegetables.Name,
                Weight = vegetables.Weight,
                Calories = vegetables.Calories
            };
        }
    }
}
