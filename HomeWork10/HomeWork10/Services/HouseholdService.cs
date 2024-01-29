using HomeWork10.Entities;
using HomeWork10.Models;
using HomeWork10.Models.Enums;
using HomeWork10.Repositories.Abstructs;
using HomeWork10.Services.Abstractions;
using System.Drawing;

namespace HomeWork10.Services
{
    internal class HouseholdService : IHouseholdService
    {
        private readonly ILoggerService _logger;
        private readonly IHouseholdRepository _repository;
        private readonly INotifyService _notify;

        public HouseholdService(IHouseholdRepository householdRepository, ILoggerService loggerService, INotifyService notifyService)
        { 
            _repository = householdRepository;
            _logger = loggerService;
            _notify = notifyService;
        }

        public string AddHousehold(string name, int consumes, Color color, TypeHousehold typeAppliance)
        {
            BrendEntity brend = new BrendEntity()
            {
                Name = "Colosok",
                Country = "Ukraine",
                BrandRegistration = "Italy"
            };

            int power = 400;

            string id = _repository.AddHousehold(name, consumes, power, brend, color, typeAppliance);
            
            string messageLog = $"succes create: {name} {consumes} {power} {color} {typeAppliance} {brend.Name}";

            _notify.Notify(NotifyType.Console, messageLog);
            _logger.Log(LogType.Info, messageLog);

            return id;
        }

        public Household GetHouseholds(string id)
        {
            HouseholdEntity entity = _repository.GetAppliances(id);

            return new Household()
            {
                Id = entity.Id,
                Name = entity.Name,
                Consumes = entity.Consumes,
                Power = entity.Power,
                Brend = new Brend()
                {
                    BrendRegistration = entity.Brend.BrandRegistration,
                    Country = entity.Brend.Country,
                    Name = entity.Brend.Name,
                },
                Color = entity.Color,
                TypeHousehold = entity.TypeHousehold
            };
        }
    }
}
