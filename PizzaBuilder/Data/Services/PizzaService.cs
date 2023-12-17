using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaBuilder.Data.Base;
using PizzaBuilder.Data.ViewModels;
using PizzaBuilder.Models;

namespace PizzaBuilder.Data.Services
{
    public class PizzaService : EntityBaseRepository<Pizza>, IPizzaService
    {
        private readonly AppDBContext _context;

        public PizzaService(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPizza(NewPizzaVM data)
        {
            var newPizza = new Pizza() { 
                Size = data.Size,
                CrustID = data.CrustId,
                Quantity = data.Quantity,
                Base_Price = data.Base_Price,                
            };
            await _context.Pizzas.AddAsync(newPizza);
            await _context.SaveChangesAsync();

            //Add Pizza Toppings
            foreach (var t in data.Toppings)
            {
                if (t.IsChecked == true)
                {
                    var newPizzaTopping = new ToppingsToPizza()
                    {
                        PizzaID = newPizza.Id,
                        ToppingID = t.Id
                    };
                    await _context.ToppingsToPizzas.AddAsync(newPizzaTopping);
                }
                
            }
            await _context.SaveChangesAsync();

        }

        public async Task<NewPizzaVM> GetNewPizzaDropDownValues()
        {
            var response = new NewPizzaVM();
            response.Crusts = await _context.Crusts.OrderBy(n => n.Id).ToListAsync();
            response.Toppings = await _context.Toppings.OrderBy(n => n.Id).ToListAsync();

            return response;
        }
    }
}
