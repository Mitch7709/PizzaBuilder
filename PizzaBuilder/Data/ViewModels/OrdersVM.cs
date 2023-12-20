using PizzaBuilder.Models;

namespace PizzaBuilder.Data.ViewModels
{
    public class OrdersVM
    {
        public List<Pizza> Pizzas { get; set; }

        public OrdersVM()
        {
            Pizzas = new List<Pizza>();
        }
    }
}
