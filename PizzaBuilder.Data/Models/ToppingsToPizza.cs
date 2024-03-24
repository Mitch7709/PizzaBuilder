namespace PizzaBuilder.Models
{
    public class ToppingsToPizza
    {
        public int PizzaID { get; set; }
        public Pizza Pizza { get; set; }
        public int ToppingID { get; set; }
        public Topping Topping { get; set; }
    }
}
