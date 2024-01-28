using Entities;

namespace Repositores.Abstraction
{
    internal interface ISweetsRepository
    {
        public string AddSweets(string name, int weight);

        public SweetsEntity GetSweets(string id);
    }
}
