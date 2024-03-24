using System.ComponentModel.DataAnnotations;

namespace PizzaBuilder.Models
{
    public class Crust
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public double Calories { get; set; }

        public List<Pizza>? Pizzas { get; set; }
    }
}
