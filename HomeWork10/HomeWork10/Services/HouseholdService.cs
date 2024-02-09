using HomeWork10.Entities;
using HomeWork10.Models;
using HomeWork10.Models.Enums;
using HomeWork10.Repositories.Abstructs;
using HomeWork10.Services.Abstractions;

namespace HomeWork10.Services
{
    internal class HouseholdService : IHouseholdService
    {
        private readonly ILoggerService _logger;
        private readonly IHouseholdRepository _repository;
        private readonly INotifyService _notify;
        private readonly IBrendRepository _brend;

        public HouseholdService(
            IHouseholdRepository householdRepository,
            ILoggerService loggerService,
            INotifyService notifyService,
            IBrendRepository brendRepository)
        {
            _repository = householdRepository;
            _logger = loggerService;
            _notify = notifyService;
            _brend = brendRepository;
        }

        public string AddHousehold(Household household)
        {
            int power = 400;

            var entity = new HouseholdEntity()
            {
                Name = household.Name,
                Brend = _brend.GetBrend(),
                Consumes = household.Consumes,
                Power = power,
                Color = household.Color,
                HouseholdType = household.HouseholdType
            };

            string id = _repository.AddHousehold(entity);

            string messageLog = $"succes create: {household.Name} {household.Consumes} {power} {household.Color} {household.HouseholdType}";

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
                HouseholdType = entity.HouseholdType
            };
        }
    }
}
