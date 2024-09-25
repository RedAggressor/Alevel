namespace HomeWork22.Datas.Entities
{
    internal class CostumerEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
