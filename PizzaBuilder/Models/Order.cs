namespace PizzaBuilder.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
