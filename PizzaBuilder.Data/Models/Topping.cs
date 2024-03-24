using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? ImageUrl { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; } = false;
        public List<ToppingsToPizza>? ToppingsToPizzas { get; set; }
    }
}
