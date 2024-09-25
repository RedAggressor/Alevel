namespace HomeWork22.Datas.Entities
{
    internal class OrderEntity
    {
        public int Id { get; set; }
        public int CostumerId { get; set; }
        public CostumerEntity? Costumer { get; set; }

        public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
    }
}
