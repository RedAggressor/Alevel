using HomeWork10.Models;

namespace HomeWork10.Services.Abstractions
{
    internal interface IInstrumentsService
    {
        public string AddInstruments(Instruments instruments);
        public Instruments GetInstruments(string id);
    }
}
