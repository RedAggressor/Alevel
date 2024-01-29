using HomeWork10.Entities;
using HomeWork10.Models.Enums;

namespace HomeWork10.Repositories.Abstructs
{
    internal interface IInstrumentsRepository
    {
        public string AddInstruments(string name, int consumes, int power, BrendEntity brend, TypeInstruments typeAppliance, int weight);
        public InstrumentsEntity GetInstruments(string id);
    }
}
