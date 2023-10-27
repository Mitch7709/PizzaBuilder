using PizzaBuilder.Models;

namespace PizzaBuilder.Data.ViewModels
{
    public class NewPizzaDropdownsVM
    {
        public NewPizzaDropdownsVM() 
        { 
            Toppings = new List<Topping>();
            Crusts = new List<Crust>();
        }

        public List<Topping> Toppings { get; set; }
        public List<Crust> Crusts { get; set; }
    }
}
