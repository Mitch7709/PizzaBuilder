namespace PizzaBuilder.Models
{
    public class TemplateToppings
    {
        public int TemplateID { get; set; }
        public PizzaTemplate Template { get; set; }
        public int ToppingID { get; set; }
        public Topping Topping { get; set; }
    }
}
