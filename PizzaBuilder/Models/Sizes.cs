using System.ComponentModel.DataAnnotations;

namespace PizzaBuilder.Models
{
    public class Sizes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Price { get; set; }
    }
}
