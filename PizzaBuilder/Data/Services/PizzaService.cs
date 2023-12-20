using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaBuilder.Data.Base;
using PizzaBuilder.Data.ViewModels;
using PizzaBuilder.Models;
using System.Net.WebSockets;

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
            var newPizza = new Pizza()
            {
                Size = data.Size,
                CrustID = data.CrustId,
                Quantity = data.Quantity,
                Base_Price = data.Base_Price,
                Instructions = data.Instructions

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

        public async Task<Pizza> GetPizzaById(int id)
        {
            var pizza = await _context.Pizzas
                .Include(c => c.Crust)
                .Include(tp => tp.ToppingsToPizzas).ThenInclude(t => t.Topping)
                .FirstOrDefaultAsync(n => n.Id == id);

            return pizza;
        }

        public async Task<NewPizzaVM> GetNewPizzaValues()
        {
            var response = new NewPizzaVM();
            response.Crusts = await _context.Crusts.OrderBy(n => n.Id).ToListAsync();
            response.Toppings = await _context.Toppings.OrderBy(n => n.Id).ToListAsync();

            return response;
        }

        public async Task<OrdersVM> GetPizzaOrders()
        {
            var orders = new OrdersVM();

            orders.Pizzas = await _context.Pizzas
                .Include(c => c.Crust)
                .Include(tp => tp.ToppingsToPizzas).ThenInclude(t => t.Topping)
                .ToListAsync();                       

            return orders;
        }

        public async Task EditPizza(NewPizzaVM data)
        {
            var dbPizza = await _context.Pizzas.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbPizza != null)
            {
                dbPizza.Size = data.Size;
                dbPizza.Quantity = data.Quantity;
                dbPizza.CrustID = dbPizza.CrustID;
                dbPizza.Base_Price = data.Base_Price;
                dbPizza.Instructions = data.Instructions;
            }

            //Remove existing toppings
            var existingTPs = _context.ToppingsToPizzas.Where(n => n.PizzaID == data.Id).ToList();
            _context.ToppingsToPizzas.RemoveRange(existingTPs);
            await _context.SaveChangesAsync();

            //Add Pizza Toppings
            foreach (var t in data.Toppings)
            {
                if (t.IsChecked == true)
                {
                    var newPizzaTopping = new ToppingsToPizza()
                    {
                        PizzaID = data.Id,
                        ToppingID = t.Id
                    };
                    await _context.ToppingsToPizzas.AddAsync(newPizzaTopping);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(n => n.Id == id);

            if (pizza != null)
            {
                EntityEntry entry = _context.Entry(pizza);
                entry.State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }
    }
}
