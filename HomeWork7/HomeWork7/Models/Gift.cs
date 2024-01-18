namespace Models
{
    internal class Gift
    {
        public string Id { get; set; }

        public List<Sweets> ListSweets { get; set; }

        public int MaxWeight { get; set; }
    }
}
