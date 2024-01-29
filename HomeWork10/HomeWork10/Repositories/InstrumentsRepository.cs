using HomeWork10.Entities;
using HomeWork10.Models.Enums;
using HomeWork10.Repositories.Abstructs;

namespace HomeWork10.Repositories
{
    internal class InstrumentsRepository : IInstrumentsRepository
    {
        private readonly List<InstrumentsEntity> _mock = new List<InstrumentsEntity>();

        public string AddInstruments(string name, int consumes, int power, BrendEntity brend, TypeInstruments typeAppliance, int weight)
        {
            InstrumentsEntity entity = new InstrumentsEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Consumes = consumes,
                Power = power,
                Brend = brend,
                Weight = weight,
                TypeInstruments = typeAppliance,
            };

            _mock.Add(entity);

            return entity.Id;
        }
        public InstrumentsEntity GetInstruments(string id)
        {
            foreach (var item in _mock)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
