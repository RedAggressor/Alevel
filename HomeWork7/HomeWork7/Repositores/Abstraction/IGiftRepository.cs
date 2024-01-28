using Entities;

namespace Repositores.Abstraction
{
    internal interface IGiftRepository
    {
        public string AddGift(int weight);

        public GiftEntity GetGift(string id);
    }
}
