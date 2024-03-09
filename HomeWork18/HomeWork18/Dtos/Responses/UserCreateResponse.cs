using Newtonsoft.Json;

namespace HomeWork18.Dtos.Responses
{
    internal class UserCreateResponse
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Id { get; set; }
        public DateTimeOffset CreateAt { get; set; }
    }
}
