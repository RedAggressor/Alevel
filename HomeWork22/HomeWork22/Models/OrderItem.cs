namespace HomeWork22.Models
{
    internal class OrderItem
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
