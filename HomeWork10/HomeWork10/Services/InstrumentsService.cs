using HomeWork10.Entities;
using HomeWork10.Models;
using HomeWork10.Models.Enums;
using HomeWork10.Repositories.Abstructs;
using HomeWork10.Services.Abstractions;
using System.Drawing;

namespace HomeWork10.Services
{
    internal class InstrumentsService : IInstrumentsService
    {
        private readonly ILoggerService _logger;
        private readonly IInstrumentsRepository _repository;
        private readonly INotifyService _notify;
        public InstrumentsService(ILoggerService loggerService, IInstrumentsRepository instrumentsRepository, INotifyService notifyService)
        { 
            _logger = loggerService;
            _notify = notifyService;
            _repository = instrumentsRepository;
        }
        public string AddInstruments(string name, int consumes, Color color, TypeInstruments typeAppliance, int weight)
        {
            BrendEntity brend = new BrendEntity()
            {
                Name = "Colosok",
                Country = "Ukraine",
                BrandRegistration = "Italy"
            };
            int power = 400;

            string id = _repository.AddInstruments(name, consumes, power, brend, typeAppliance, weight);

            string messageLog = $"succes create: {name} {consumes} {power} {color} {typeAppliance} {brend.Name} {weight}";

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
                TypeInstruments = entity.TypeInstruments
            };
        }
    }
}
