using Models;

namespace Services.Abstraction
{
    internal interface IGiftService
    {
        public string CreateGift(int weight);

        public Gift GetGift(string id);

        public void AddToGift(string id, Sweets sweets);

        public List<Sweets> GetListOfSweets(string id);
    }
}
