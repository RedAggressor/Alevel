using Entities;
using Models;
using Repositoreis.Abstract;
using Services.Abstract;

namespace Services
{
    internal class VegetableService : IVegetablesService
    {
        private IVegetablesRepository _repository;
        private ILoggerService _logger;
        private INotifyService _notify;

        public VegetableService(IVegetablesRepository vegetablesRepository,ILoggerService loggerService, INotifyService notifyService)
        {
            _repository = vegetablesRepository;
            _logger = loggerService;
            _notify = notifyService;
        }

        public virtual string AddVegetable(double weight)
        {
            string name = "Vegetables";

            double calories = 0;

            string id = _repository.AddVegetables(name, weight, calories);

            string messageLog = $"Create vegetables was succesfull id {id}";

            string toSend = "adress Console";

            string messageNotify = "Message send to";

            _logger.Log(TypeLog.Info, messageLog);

            _notify.Notify(TypeNoti.Console, messageNotify, toSend);

            return id;
        }

        public virtual Vegetables GetVegetables(string id)
        {
            VegetablesEntity? vegetables = _repository.GetVegetables(id);

            return new Vegetables()
            {
                Id = id,
                Name = vegetables.Name,
                Weight = vegetables.Weight,
                Calories = vegetables.Calories
            };
        }
    }
}
