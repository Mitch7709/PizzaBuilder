using System.ComponentModel.DataAnnotations;

namespace PizzaBuilder.Models
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public double Calories { get; set; }
        public string ImageUrl { get; set; }

        public List<ToppingsToPizza>? ToppingsToPizzas { get; set; }
    }
}
