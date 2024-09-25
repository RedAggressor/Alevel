namespace HomeWork22.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public Costumer? Costumer { get; set; }
        public IEnumerable<OrderItem>? OrderItem { get; set; }
    }
}
