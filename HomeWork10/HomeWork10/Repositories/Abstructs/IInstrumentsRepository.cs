using HomeWork10.Entities;

namespace HomeWork10.Repositories.Abstructs
{
    internal interface IInstrumentsRepository
    {
        public string AddInstruments(InstrumentsEntity instruments);
        public InstrumentsEntity GetInstruments(string id);
    }
}
