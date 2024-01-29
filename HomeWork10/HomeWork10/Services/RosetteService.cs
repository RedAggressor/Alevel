using HomeWork10.Models;
using HomeWork10.Models.Enums;
using HomeWork10.Services.Abstractions;

namespace HomeWork10.Services
{
    internal class RosetteService : IRosetteService
    {
        private readonly ILoggerService _logger;
        
        public RosetteService(ILoggerService loggerService)
        {
            _logger = loggerService;
        }

        public ElectricalAppliances СonnecDisconectDevice(ElectricalAppliances electricalAppliances, bool jumper = false)
        {
            electricalAppliances.TornOn = jumper;

            _logger.Log(LogType.Info, $"{electricalAppliances.Name} connected to rosette torn on: {electricalAppliances.TornOn}");

            return electricalAppliances;
        }
    }
}
