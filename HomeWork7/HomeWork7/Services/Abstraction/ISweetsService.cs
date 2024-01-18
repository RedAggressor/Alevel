using Models;

namespace Services.Abstraction
{
    internal interface ISweetsService
    {
        public string AddSweets(string name, int weight);
        
        public Sweets GetSweets(string id);

        public string GetFullInfo(string id);
    }
}
