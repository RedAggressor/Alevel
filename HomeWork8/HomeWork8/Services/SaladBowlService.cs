using Models;
using Repositoreis.Abstract;
using Services.Abstract;
using Entities;

namespace Services
{
    internal class SaladBowlService : ISaladBowlService
    {
        private ISaladBowlReposotory _repository;
        private ILoggerService _logger;
        private INotifyService _notify;
        private IVegetablesService _vegetableService;

        public SaladBowlService(ISaladBowlReposotory salatBowlReposotory, ILoggerService loggerService, INotifyService notifyService)
        { 
            _repository = salatBowlReposotory;
            _logger = loggerService;
            _notify = notifyService;
        }

        public string AddSalad(List<Vegetables> ingridiensList, string name)
        {
            double weight = ingridiensList.Select(p => p.Weight).Sum();

            string id = _repository.AddCaladBowl(weight, name, ingridiensList);

            string messageLog = GetFullInfoSalad(id);

            string toSend = "adress Console";

            string messageNotify = "Message send to";

            _logger.Log(TypeLog.Info, messageLog);

            _notify.Notify(TypeNoti.Console, messageNotify, toSend);

            return id;
        }

        public SaladBowl GetSalad(string id)
        {
            SaladBowlEntity saladBowl = _repository.GetSaladBowl(id);
            return new SaladBowl() 
            { 
                Id =saladBowl.Id,
                Name = saladBowl.Name,
                Weight = saladBowl.Weight,
                VegetablesList = saladBowl.VegetablesList,
                Calories = saladBowl.VegetablesList.Select(p=>p.Calories).Sum()
            };
        }

        public string GetFullInfoSalad(string id)
        {
            SaladBowl saladBowl = GetSalad(id);

            return $"Name:{saladBowl.Name}, weieght:{saladBowl.Weight}, calories {saladBowl.Calories}, countingridiens {saladBowl.VegetablesList.Count()}";
        }

        public Vegetables GeneretIngridient(double weight, double percent, IVegetablesService vegetablesService)
        {
            _vegetableService = vegetablesService;

            double weightIngridient = (weight * percent) / 100;
            
            string id = _vegetableService.AddVegetable(weightIngridient);

            Vegetables ingridient = _vegetableService.GetVegetables(id);

            return ingridient;
        }
 
    }
}
