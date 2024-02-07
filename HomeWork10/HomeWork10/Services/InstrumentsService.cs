using HomeWork10.Entities;
using HomeWork10.Models;
using HomeWork10.Models.Enums;
using HomeWork10.Repositories.Abstructs;
using HomeWork10.Services.Abstractions;

namespace HomeWork10.Services
{
    internal class InstrumentsService : IInstrumentsService
    {
        private readonly ILoggerService _logger;
        private readonly IInstrumentsRepository _repository;
        private readonly INotifyService _notify;
        private readonly IBrendRepository _brend;
        public InstrumentsService(
            ILoggerService loggerService,
            IInstrumentsRepository instrumentsRepository,
            INotifyService notifyService,
            IBrendRepository brendRepository)
        { 
            _logger = loggerService;
            _notify = notifyService;
            _repository = instrumentsRepository;
            _brend = brendRepository;
        }
        public string AddInstruments(Instruments instruments)
        {
            int power = 400;

            InstrumentsEntity entity = new InstrumentsEntity()
            {
                Name = instruments.Name,
                Consumes = instruments.Consumes,
                Brend = _brend.GetBrend(),
                Power = power,
                Weight = instruments.Weight,
                InstrumentsType = instruments.InstrumentsType

            };

            string id = _repository.AddInstruments(entity);

            string messageLog = $"succes create: {instruments.Name} {instruments.Consumes} {power} {instruments.InstrumentsType} {brend.Name} {instruments.Weight}";

            _notify.Notify(NotifyType.Console, messageLog);
            _logger.Log(LogType.Info, messageLog);

            return id;
        }

        public Instruments GetInstruments(string id)
        {
            InstrumentsEntity entity = _repository.GetInstruments(id);
             
            return new Instruments()
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
                Weight = entity.Weight,
                InstrumentsType = entity.InstrumentsType
            };
        }
    }
}
