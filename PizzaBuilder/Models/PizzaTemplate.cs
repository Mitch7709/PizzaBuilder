namespace PizzaBuilder.Models
{
    public class PizzaTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<TemplateToppings>? TemplateToppings { get; set; }
    }
}
