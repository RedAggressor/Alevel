using HomeWork10.Entities;
using HomeWork10.Repositories.Abstructs;

namespace HomeWork10.Repositories
{
    internal class InstrumentsRepository : IInstrumentsRepository
    {
        private readonly List<InstrumentsEntity> _mock = new List<InstrumentsEntity>();

        public string AddInstruments(InstrumentsEntity instruments)
        {
            InstrumentsEntity entity = new InstrumentsEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = instruments.Name,
                Consumes = instruments.Consumes,
                Power = instruments.Power,
                Brend = instruments.Brend,
                Weight = instruments.Weight,
                InstrumentsType = instruments.InstrumentsType
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
