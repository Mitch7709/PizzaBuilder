using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaBuilder.Data.Enums;
using PizzaBuilder.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzaBuilder.Data.ViewModels
{
    public class NewPizzaVM
    {
        public int Id { get; set; }

        [Required]
        public PizzaSize Size { get; set; }

        [Required]
        public int Quantity { get; set; }
        public double Base_Price { get; set; }
        public string? Instructions { get; set; }

        public List<Topping> Toppings { get; set; }

        public int CrustId { get; set; }
        public List<Crust> Crusts { get; set; }

        public NewPizzaVM()
        {
            Size = PizzaSize.Large;
            Quantity = 1;
            Base_Price = 12.99;
            Crusts = new List<Crust>();
            Toppings = new List<Topping>();
            Instructions = string.Empty;
        }
    }
}
