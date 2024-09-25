namespace HomeWork22.Datas.Entities
{
    internal class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }

        public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
    }
}
