using Entities;
using Models;
using Repositoreis.Abstract;
using Services.Abstract;

namespace Services
{
    internal class CornService : VegetableService
    {
        private IVegetablesRepository _repository;
        private ILoggerService _logger;
        private INotifyService _notify;

        public CornService(IVegetablesRepository vegetablesRepository, ILoggerService loggerService, INotifyService notifyService) : base(vegetablesRepository, loggerService, notifyService)
        {
            _repository = vegetablesRepository;
            _logger = loggerService;
            _notify = notifyService;
        }

        public override string AddVegetable(double weight)
        {
            string name = "Corn";

            double calories = 0.94;

            string id = _repository.AddVegetables(name, weight, calories);

            string messageLog = $"Create {name} was succesfull id {id}";

            string toSend = "adress Console";

            string messageNotify = "Message send to";

            _logger.Log(TypeLog.Info, messageLog);

            _notify.Notify(TypeNoti.Console, messageNotify, toSend);

            return id;
        }

        public override Corn GetVegetables(string id)
        {
            CornEntity? vegetables = (CornEntity?)_repository.GetVegetables(id);

            return new Corn()
            {
                Id = id,
                Name = vegetables.Name,
                Weight = vegetables.Weight,
                Calories = vegetables.Calories
            };
        }
    }
}
